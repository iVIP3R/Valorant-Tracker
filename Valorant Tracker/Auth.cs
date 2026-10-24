using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.JsonWebTokens;
using Newtonsoft.Json.Linq;

namespace Valorant_Tracker
{
    /// <summary>
    /// Authenticated Riot identity produced by the WebView login flow.
    /// Keeps the surface that <see cref="Content.Get"/> and other Riot client
    /// code depends on (<see cref="cookies"/>, <see cref="Region"/>,
    /// <see cref="AccessToken"/>, <see cref="ClientVersion"/>, <see cref="Subject"/>),
    /// and adds a factory (<see cref="CreateFromAccessTokenAsync"/>) plus a
    /// bridge to <see cref="RiotSession"/> (<see cref="ToRiotSession"/>).
    /// </summary>
    public class Auth
    {
        static Auth()
        {
            // Riot's auth endpoints still reject TLS 1.0/1.1 handshakes on some
            // Windows builds. Matches the pre-WebView version.
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        private const string EntitlementsEndpoint = "https://entitlements.auth.riotgames.com/api/token/v1";
        private const string ClientVersionEndpoint = "https://valorant-api.com/v1/version";

        private static readonly HttpClient Http = CreateHttpClient();
        private static string _cachedClientVersion;
        private static readonly object _clientVersionSync = new object();

        private static HttpClient CreateHttpClient()
        {
            var client = new HttpClient { Timeout = TimeSpan.FromSeconds(20) };
            client.DefaultRequestHeaders.UserAgent.ParseAdd("ValorantTracker/1.0");
            return client;
        }

        public string AccessToken { get; set; }
        public string EntitlementToken { get; set; }
        public string Subject { get; set; }
        public CookieContainer cookies { get; set; } = new CookieContainer();
        public string ClientVersion { get; set; }
        public region Region { get; set; }

        // --- New surface ---
        public string IdToken { get; set; }
        public DateTimeOffset ExpiresAt { get; set; }
        public bool IsExpired => DateTimeOffset.UtcNow >= ExpiresAt;

        /// <summary>
        /// Lowercase shard (na, eu, ap, ko) for Riot's shard-specific hostnames.
        /// The enum's default ToString is uppercase, which Riot's endpoints reject.
        /// </summary>
        public string RegionShard => Region.ToString().ToLowerInvariant();

        private Auth() { }

        /// <summary>
        /// Builds an <see cref="Auth"/> from the OAuth tokens intercepted by
        /// <see cref="WebViewAuthHandler"/>. Performs the entitlement exchange
        /// and resolves the current Valorant client version.
        /// </summary>
        public static async Task<Auth> CreateFromAccessTokenAsync(
            string accessToken, string idToken, region shard, int expiresInSeconds)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
                throw new ArgumentException("Access token is empty.", nameof(accessToken));

            var subject = ExtractSubject(accessToken);
            var entitlement = await FetchEntitlementTokenAsync(accessToken).ConfigureAwait(false);
            var version = await GetClientVersionAsync().ConfigureAwait(false);
            var effectiveLifetime = Math.Max(expiresInSeconds - 60, 30);

            return new Auth
            {
                AccessToken = accessToken,
                IdToken = idToken,
                EntitlementToken = entitlement,
                Subject = subject,
                Region = shard,
                ClientVersion = version,
                ExpiresAt = DateTimeOffset.UtcNow.AddSeconds(effectiveLifetime)
            };
        }

        /// <summary>Projects this <see cref="Auth"/> into the lighter <see cref="RiotSession"/>.</summary>
        public RiotSession ToRiotSession()
        {
            return new RiotSession(
                AccessToken,
                EntitlementToken,
                Subject,
                Region,
                ClientVersion,
                ExpiresAt);
        }

        private static async Task<string> FetchEntitlementTokenAsync(string accessToken)
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, EntitlementsEndpoint)
            {
                Content = new StringContent("{}", Encoding.UTF8, "application/json")
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            using var response = await Http.SendAsync(request).ConfigureAwait(false);
            var body = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new AuthException(
                    $"Riot's entitlement service returned {(int)response.StatusCode} {response.ReasonPhrase}.",
                    body);
            }

            string token;
            try
            {
                token = JObject.Parse(body)["entitlements_token"]?.ToString();
            }
            catch (Newtonsoft.Json.JsonException ex)
            {
                throw new AuthException(
                    "Riot's entitlement service returned a malformed response.", ex);
            }

            if (string.IsNullOrWhiteSpace(token))
                throw new AuthException("Riot did not return an entitlement token.", body);

            return token;
        }

        private static async Task<string> GetClientVersionAsync()
        {
            lock (_clientVersionSync)
            {
                if (!string.IsNullOrEmpty(_cachedClientVersion))
                    return _cachedClientVersion;
            }

            string body;
            try
            {
                using var response = await Http.GetAsync(ClientVersionEndpoint).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                body = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new AuthException(
                    "Unable to resolve the current Valorant client version from " +
                    "valorant-api.com. Check your network connection and try again.", ex);
            }

            string version;
            try
            {
                version = JObject.Parse(body)["data"]?["riotClientVersion"]?.ToString();
            }
            catch (Newtonsoft.Json.JsonException ex)
            {
                throw new AuthException(
                    "valorant-api.com returned a version payload that could not be parsed.", ex);
            }

            if (string.IsNullOrWhiteSpace(version))
            {
                throw new AuthException(
                    "valorant-api.com's version payload did not include riotClientVersion.", body);
            }

            lock (_clientVersionSync) { _cachedClientVersion = version; }
            return version;
        }

        private static string ExtractSubject(string jwt)
        {
            try
            {
                // Microsoft.IdentityModel.JsonWebTokens parses without validating
                // the signature by default; we already trust the token because it
                // arrived over TLS from Riot's redirect.
                return new JsonWebToken(jwt).Subject;
            }
            catch (Exception ex)
            {
                throw new AuthException("Access token could not be parsed as a JWT.", ex);
            }
        }
    }

    /// <summary>
    /// Raised when the auth or entitlement exchange fails in a way the caller
    /// should surface to the user.
    /// </summary>
    public sealed class AuthException : Exception
    {
        /// <summary>The raw response body from Riot, if the failure came from an HTTP call.</summary>
        public string ResponseBody { get; }

        public AuthException(string message, string responseBody = null)
            : base(message) { ResponseBody = responseBody; }

        public AuthException(string message, Exception inner)
            : base(message, inner) { }
    }
}