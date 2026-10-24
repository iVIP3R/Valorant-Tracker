using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Valorant_Tracker
{
    class Content
    {
        public List<Character> Characters { get; set; }
        public List<Map> Maps { get; set; }
        public List<Chroma> Chromas { get; set; }
        public List<Skin> Skins { get; set; }
        public List<SkinLevel> SkinLevels { get; set; }
        public List<Attachment> Attachments { get; set; }
        public List<Equip> Equips { get; set; }
        public List<Theme> Themes { get; set; }
        public List<GameMode> GameModes { get; set; }
        public List<Spray> Sprays { get; set; }
        public List<SprayLevel> SprayLevels { get; set; }
        public List<Charm> Charms { get; set; }
        public List<CharmLevel> CharmLevels { get; set; }
        public List<PlayerCard> PlayerCards { get; set; }
        public List<PlayerTitle> PlayerTitles { get; set; }
        public List<StorefrontItem> StorefrontItems { get; set; }
        public List<Season> Seasons { get; set; }
        public List<CompetitiveSeason> CompetitiveSeasons { get; set; }
        public List<Event> Events { get; set; }
        public int StatusCode { get; set; }

        // =====================================================================
        // NEW: valorant-api.com skin lookup result (consumed by Store.cs)
        // =====================================================================

        /// <summary>
        /// Populated by <see cref="Search"/>. Null when this instance came from
        /// <see cref="Get"/> instead.
        /// </summary>
        public ContentData data { get; set; }

        public class ContentData
        {
            public string uuid { get; set; }
            public string displayName { get; set; }
            public string displayIcon { get; set; }
        }

        public class Character { 
            public string Name { get; set; } 
            public string ID { get; set; } 
            public string AssetName { get; set; } 
            public bool IsEnabled { get; set; } 
        }

        public class Map { 
            public string Name { get; set; } 
            public string ID { get; set; } 
            public string AssetName { get; set; } 
            public bool IsEnabled { get; set; } 
        }

        public class Chroma { 
            public string Name { get; set; }
            public string ID { get; set; }
            public string AssetName { get; set; }
            public bool IsEnabled { get; set; }
        }

        public class Skin { 
            public string Name { get; set; } 
            public string ID { get; set; } 
            public string AssetName { get; set; } 
            public bool IsEnabled { get; set; } 
        }

        public class SkinLevel { 
            public string Name { get; set; } 
            public string ID { get; set; } 
            public string AssetName { get; set; } 
            public bool IsEnabled { get; set; } 
        }

        public class Attachment { 
            public string Name { get; set; } 
            public string ID { get; set; } 
            public string AssetName { get; set; } 
            public bool IsEnabled { get; set; } 
        }

        public class Equip { 
            public string Name { get; set; } 
            public string ID { get; set; } 
            public string AssetName { get; set; } 
            public bool IsEnabled { get; set; } 
        }

        public class Theme { 
            public string Name { get; set; } 
            public string ID { get; set; } 
            public string AssetName { get; set; } 
            public bool IsEnabled { get; set; } 
        }

        public class GameMode { 
            public string Name { get; set; } 
            public string ID { get; set; } 
            public string AssetName { get; set; } 
            public bool IsEnabled { get; set; } 
        }

        public class Spray { 
            public string Name { get; set; } 
            public string ID { get; set; } 
            public string AssetName { get; set; } 
            public bool IsEnabled { get; set; } 
        }

        public class SprayLevel { 
            public string Name { get; set; } 
            public string ID { get; set; } 
            public string AssetName { get; set; }
            public bool IsEnabled { get; set; } 
        }

        public class Charm { 
            public string Name { get; set; } 
            public string ID { get; set; } 
            public string AssetName { get; set; } 
            public bool IsEnabled { get; set; } 
        }

        public class CharmLevel { 
            public string Name { get; set; } 
            public string ID { get; set; } 
            public string AssetName { get; set; } 
            public bool IsEnabled { get; set; } 
        }

        public class PlayerCard { 
            public string Name { get; set; } 
            public string ID { get; set; } 
            public string AssetName { get; set; } 
            public bool IsEnabled { get; set; } 
        }

        public class PlayerTitle { 
            public string Name { get; set; } 
            public string ID { get; set; } 
            public string AssetName { get; set; } 
            public bool IsEnabled { get; set; } 
        }

        public class StorefrontItem { 
            public string Name { get; set; } 
            public string ID { get; set; } 
            public string AssetName { get; set; } 
            public bool IsEnabled { get; set; } 
        }

        public class Season
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public bool IsEnabled { get; set; }
            public bool IsActive { get; set; }
            public bool DevelopmentOnly { get; set; }
        }

        public class CompetitiveSeason
        {
            public string ID { get; set; }
            public string SeasonID { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public bool DevelopmentOnly { get; set; }
        }

        public class Event
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public bool IsEnabled { get; set; }
            public bool IsActive { get; set; }
            public bool DevelopmentOnly { get; set; }
        }

        public static Content Get(Auth au)
        {
            if (au == null) throw new ArgumentNullException(nameof(au));

            string URL = "https://shared." + au.RegionShard + ".a.pvp.net/content-service/v2/content";
            var client = new RestClient(URL);
            if (au.cookies != null) client.CookieContainer = au.cookies;

            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {au.AccessToken}");
            request.AddHeader("X-Riot-ClientPlatform", Info.ClientPlatform);
            request.AddHeader("X-Riot-ClientVersion", au.ClientVersion);

            var response = client.Execute(request);
            var ret = JsonConvert.DeserializeObject<Content>(response.Content) ?? new Content();
            ret.StatusCode = (int)response.StatusCode;
            return ret;
        }

        private const string ValorantApiBase = "https://valorant-api.com/v1/weapons";

        private static readonly HttpClient ValApiHttp = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(15)
        };

        private static readonly ConcurrentDictionary<string, Content> SearchCache =
            new ConcurrentDictionary<string, Content>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Resolves a skin UUID from the storefront to its display name and icon.
        /// Riot returns skin-*level* UUIDs in <c>Rewards[].ItemID</c>, so we hit
        /// /v1/weapons/skinlevels/ first. The /v1/weapons/skins/ fallback exists
        /// only because Riot has changed this in the past — if it fires, log it
        /// so a future maintainer notices.
        /// </summary>
        public static Content Search(Auth au, string skinUuid)
        {
            if (string.IsNullOrWhiteSpace(skinUuid)) return null;
            if (SearchCache.TryGetValue(skinUuid, out var cached)) return cached;

            var data = TryFetch(skinUuid, "skinlevels") ?? TryFetch(skinUuid, "skins");
            if (data == null) return null;

            var content = new Content { data = data };
            SearchCache[skinUuid] = content;
            return content;
        }

        private static ContentData TryFetch(string uuid, string segment)
        {
            try
            {
                var url = $"{ValorantApiBase}/{segment}/{Uri.EscapeDataString(uuid)}";
                var body = ValApiHttp.GetStringAsync(url).GetAwaiter().GetResult();
                var root = JObject.Parse(body);
                if (root["status"]?.Value<int>() != 200) return null;

                var data = root["data"]?.ToObject<ContentData>();
                if (data == null || string.IsNullOrWhiteSpace(data.displayName)) return null;

                if (string.IsNullOrWhiteSpace(data.displayIcon)
                    && root["data"]?["chromas"] is JArray chromas
                    && chromas.Count > 0
                    && chromas[0] is JObject chroma)
                {
                    data.displayIcon = chroma["fullRender"]?.ToString();
                }

                if (string.IsNullOrWhiteSpace(data.displayIcon))
                    Debug.WriteLine($"[Content] {uuid} resolved via /{segment} but has no icon.");
                return data;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                // Expected on the first attempt for skin-level UUIDs. Silent.
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Content] {uuid} via /{segment} failed: {ex.GetType().Name}: {ex.Message}");
                return null;
            }
        }
    }
}