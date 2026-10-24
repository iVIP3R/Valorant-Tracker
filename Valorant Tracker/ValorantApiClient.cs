using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Valorant_Tracker
{
    /// <summary>Single authenticated transport for player-data and public content calls.</summary>
    public sealed class ValorantApiClient : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly RiotSession _session;

        public ValorantApiClient(RiotSession session, HttpMessageHandler handler = null)
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
            _httpClient = handler == null ? new HttpClient() : new HttpClient(handler, true);
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<T> GetPlayerDataAsync<T>(string path, CancellationToken cancellationToken = default)
        {
            using var request = CreatePlayerDataRequest(HttpMethod.Get, path);
            return await SendAsync<T>(request, cancellationToken).ConfigureAwait(false);
        }

        public async Task<T> PostPlayerDataAsync<T>(string path, HttpContent? content = null, CancellationToken cancellationToken = default)
        {
            using var request = CreatePlayerDataRequest(HttpMethod.Post, path, content);
            return await SendAsync<T>(request, cancellationToken).ConfigureAwait(false);
        }

        public async Task<T> GetPublicAsync<T>(string path, CancellationToken cancellationToken = default)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, new Uri("https://valorant-api.com/" + path.TrimStart('/')));
            return await SendAsync<T>(request, cancellationToken).ConfigureAwait(false);
        }

        public Task<byte[]> GetBytesAsync(string url, CancellationToken cancellationToken = default) =>
            _httpClient.GetByteArrayAsync(url, cancellationToken);

        private HttpRequestMessage CreatePlayerDataRequest(HttpMethod method, string path, HttpContent? content = null)
        {
            var request = new HttpRequestMessage(
                method,
                new Uri(
                    $"https://pd.{_session.Shard.ToString().ToLowerInvariant()}.a.pvp.net/{path.TrimStart('/')}"
                )
            );

            request.Content = content;

            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", _session.AccessToken);

            request.Headers.TryAddWithoutValidation(
                "X-Riot-Entitlements-JWT",
                _session.EntitlementToken
            );

            request.Headers.TryAddWithoutValidation(
                "X-Riot-ClientPlatform",
                Info.ClientPlatform
            );

            request.Headers.TryAddWithoutValidation(
                "X-Riot-ClientVersion",
                _session.ClientVersion
            );

            return request;
        }

        private async Task<T> SendAsync<T>(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            using var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Riot API returned {(int)response.StatusCode} ({response.ReasonPhrase}).", null, response.StatusCode);
            return JsonConvert.DeserializeObject<T>(content);
        }

        public void Dispose() => _httpClient.Dispose();
    }
}