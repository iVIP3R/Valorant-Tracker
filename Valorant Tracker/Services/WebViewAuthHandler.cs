using System;
using System.Collections.Generic;

namespace Valorant_Tracker.Services
{
    public static class WebViewAuthHandler
    {
        public const string RedirectHost = "playvalorant.com";
        public const string AuthorizeUrl = "https://auth.riotgames.com/authorize?client_id=play-valorant-web-prod&redirect_uri=https%3A%2F%2Fplayvalorant.com%2Fopt_in&response_type=token%20id_token&scope=account%20openid&nonce=1";

        public static bool TryParseRedirect(Uri uri, out string accessToken, out string idToken, out int expiresIn)
        {
            accessToken = null;
            idToken = null;
            expiresIn = 0;
            if (uri == null || !uri.Host.Equals(RedirectHost, StringComparison.OrdinalIgnoreCase) || String.IsNullOrEmpty(uri.Fragment)) return false;

            var values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var part in uri.Fragment.TrimStart('#').Split('&', StringSplitOptions.RemoveEmptyEntries))
            {
                var pair = part.Split('=', 2);
                values[Uri.UnescapeDataString(pair[0])] = pair.Length == 2 ? Uri.UnescapeDataString(pair[1]) : String.Empty;
            }

            if (!values.TryGetValue("access_token", out accessToken) || String.IsNullOrWhiteSpace(accessToken)) return false;
            values.TryGetValue("id_token", out idToken);
            if (values.TryGetValue("expires_in", out var rawExpiry)) Int32.TryParse(rawExpiry, out expiresIn);
            return true;
        }
    }
}