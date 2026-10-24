using System;

namespace Valorant_Tracker
{
    /// <summary>Authenticated Riot identity kept only in memory for this app session.</summary>
    public sealed class RiotSession
    {
        public RiotSession(string accessToken, string entitlementToken, string subject, region shard, string clientVersion, DateTimeOffset expiresAt)
        {
            AccessToken = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
            EntitlementToken = entitlementToken ?? throw new ArgumentNullException(nameof(entitlementToken));
            Subject = subject ?? throw new ArgumentNullException(nameof(subject));
            Shard = shard;
            ClientVersion = clientVersion ?? throw new ArgumentNullException(nameof(clientVersion));
            ExpiresAt = expiresAt;
        }

        public string AccessToken { get; }
        public string EntitlementToken { get; }
        public string Subject { get; }
        public region Shard { get; }
        public string ClientVersion { get; }
        public DateTimeOffset ExpiresAt { get; }
        public bool IsExpired => DateTimeOffset.UtcNow >= ExpiresAt;
    }
}