using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Valorant_Tracker
{
    /// <summary>
    /// Process-wide cache for valorant-api.com reference data: seasons (acts),
    /// agents, and maps. Each list is fetched lazily on first access and cached
    /// for the lifetime of the process.
    /// </summary>
    public static class ValorantDataService
    {
        private const string BaseUrl = "https://valorant-api.com/v1";

        // valorant-api.com encodes season types as "EAresSeasonType::Act" rather
        // than a plain "act". Compared case-insensitively in GetActsAsync.
        private const string ActTypeMarker = "EAresSeasonType::Act";

        private static readonly HttpClient Http = CreateHttpClient();

        private static HttpClient CreateHttpClient()
        {
            var client = new HttpClient { Timeout = TimeSpan.FromSeconds(15) };
            client.DefaultRequestHeaders.UserAgent.ParseAdd("ValorantTracker/1.0");
            return client;
        }

        /// <summary>
        /// All seasons (episodes, acts, closed beta) from /v1/seasons. Use
        /// <see cref="GetActsAsync"/> for the filtered act list suitable for the
        /// season/act picker.
        /// </summary>
        public static Task<IReadOnlyList<ValorantSeason>> GetSeasonsAsync() =>
            Cache<ValorantSeason>.GetAsync($"{BaseUrl}/seasons");

        public static Task<IReadOnlyList<ValorantAgent>> GetAgentsAsync() =>
            Cache<ValorantAgent>.GetAsync($"{BaseUrl}/agents?isPlayableCharacter=true");

        public static Task<IReadOnlyList<ValorantMap>> GetMapsAsync() =>
            Cache<ValorantMap>.GetAsync($"{BaseUrl}/maps");

        /// <summary>
        /// Acts only, sorted chronologically (oldest first), with DisplayLabel set
        /// to a human-readable label like "EPISODE 8 // ACT III" or "V25 // ACT IV".
        /// Excludes episodes, closed beta, and events.
        /// </summary>
        public static async Task<IReadOnlyList<ValorantSeason>> GetActsAsync()
        {
            var all = await GetSeasonsAsync().ConfigureAwait(false);

            // Index by uuid so we can resolve parent labels.
            var byUuid = new Dictionary<string, ValorantSeason>(StringComparer.OrdinalIgnoreCase);
            foreach (var s in all)
                if (!string.IsNullOrEmpty(s.Uuid))
                    byUuid[s.Uuid] = s;

            var acts = new List<ValorantSeason>(all.Count);
            foreach (var s in all)
            {
                if (!string.Equals(s.Type, ActTypeMarker, StringComparison.OrdinalIgnoreCase))
                    continue;

                // Prefer the API-provided title ("V25 // ACT I"); otherwise build
                // one from the parent episode's displayName ("EPISODE 8 // ACT III");
                // otherwise fall back to just the displayName ("ACT I").
                if (!string.IsNullOrWhiteSpace(s.Title))
                {
                    s.DisplayLabel = s.Title;
                }
                else if (!string.IsNullOrEmpty(s.ParentUuid)
                      && byUuid.TryGetValue(s.ParentUuid, out var parent)
                      && !string.IsNullOrWhiteSpace(parent.DisplayName))
                {
                    s.DisplayLabel = $"{parent.DisplayName} // {s.DisplayName}";
                }
                else
                {
                    s.DisplayLabel = s.DisplayName;
                }

                acts.Add(s);
            }

            acts.Sort((a, b) =>
            {
                if (a.StartTime == null && b.StartTime == null) return 0;
                if (a.StartTime == null) return -1;
                if (b.StartTime == null) return 1;
                return a.StartTime.Value.CompareTo(b.StartTime.Value);
            });
            return acts;
        }

        /// <summary>
        /// The act currently being played, derived from StartTime/EndTime.
        /// Returns null between acts.
        /// </summary>
        public static async Task<ValorantSeason> GetCurrentActAsync()
        {
            var acts = await GetActsAsync().ConfigureAwait(false);
            var now = DateTime.UtcNow;
            ValorantSeason current = null;
            foreach (var act in acts)
            {
                if (!act.StartTime.HasValue) continue;
                if (act.StartTime.Value > now) continue;
                if (act.EndTime.HasValue && act.EndTime.Value < now) continue;
                if (current == null || act.StartTime.Value > current.StartTime.Value)
                    current = act;
            }
            return current;
        }

        public static async Task<ValorantSeason> FindSeasonAsync(string uuid)
        {
            if (string.IsNullOrWhiteSpace(uuid)) return null;
            var seasons = await GetSeasonsAsync().ConfigureAwait(false);
            foreach (var s in seasons)
                if (string.Equals(s.Uuid, uuid, StringComparison.OrdinalIgnoreCase))
                    return s;
            return null;
        }

        public static async Task<ValorantAgent> FindAgentAsync(string uuid)
        {
            if (string.IsNullOrWhiteSpace(uuid)) return null;
            var agents = await GetAgentsAsync().ConfigureAwait(false);
            foreach (var a in agents)
                if (string.Equals(a.Uuid, uuid, StringComparison.OrdinalIgnoreCase))
                    return a;
            return null;
        }

        public static async Task<ValorantMap> FindMapAsync(string assetPath)
        {
            if (string.IsNullOrWhiteSpace(assetPath)) return null;
            var maps = await GetMapsAsync().ConfigureAwait(false);
            foreach (var m in maps)
                if (string.Equals(m.AssetPath, assetPath, StringComparison.OrdinalIgnoreCase))
                    return m;
            return null;
        }

        private static class Cache<T>
        {
            private static readonly object _lock = new object();
            private static IReadOnlyList<T> _value;
            private static Task<IReadOnlyList<T>> _inflight;

            public static Task<IReadOnlyList<T>> GetAsync(string url)
            {
                lock (_lock)
                {
                    if (_value != null) return Task.FromResult(_value);
                    if (_inflight == null || _inflight.IsFaulted || _inflight.IsCanceled)
                        _inflight = FetchAsync(url);
                    return _inflight;
                }
            }

            private static async Task<IReadOnlyList<T>> FetchAsync(string url)
            {
                var body = await Http.GetStringAsync(url).ConfigureAwait(false);
                var envelope = JsonConvert.DeserializeObject<VapiEnvelope<List<T>>>(body);
                if (envelope == null)
                    throw new InvalidOperationException(
                        $"valorant-api.com returned an empty response for {url}.");
                if (envelope.Status != 200)
                    throw new InvalidOperationException(
                        $"valorant-api.com returned status {envelope.Status} for {url}.");
                var result = (IReadOnlyList<T>)envelope.Data ?? new List<T>();
                _value = result;
                return result;
            }
        }

        private sealed class VapiEnvelope<T>
        {
            public int Status { get; set; }
            public T Data { get; set; }
        }
    }

    public sealed class ValorantSeason
    {
        public string Uuid { get; set; }
        public string DisplayName { get; set; }
        /// <summary>"EAresSeasonType::Act" for acts, null for episodes/closed beta.</summary>
        public string Type { get; set; }
        /// <summary>"V25 // ACT I" for newer acts, null for older ones.</summary>
        public string Title { get; set; }
        public string ParentUuid { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Set by GetActsAsync(). Readable label for combo boxes: "V25 // ACT IV",
        /// "EPISODE 8 // ACT III", etc. Null on seasons that haven't been through
        /// GetActsAsync.
        /// </summary>
        [JsonIgnore]
        public string DisplayLabel { get; set; }

        /// <summary>For ComboBox DataSource binding — falls back to DisplayName if DisplayLabel wasn't set.</summary>
        public override string ToString() => DisplayLabel ?? DisplayName ?? Uuid;
    }

    public sealed class ValorantAgent
    {
        public string Uuid { get; set; }
        public string DisplayName { get; set; }
        public string DisplayIcon { get; set; }
        public string FullPortrait { get; set; }
    }

    public sealed class ValorantMap
    {
        public string Uuid { get; set; }
        public string DisplayName { get; set; }
        public string AssetPath { get; set; }
        public string ListViewIcon { get; set; }
        public string Splash { get; set; }
    }
}