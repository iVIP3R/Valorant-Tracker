namespace Valorant_Tracker.Utils
{
    public enum region
    {
        EU,
        NA,
        AP,
        KO
    }

    public readonly struct Info
    {
        public static string ClientPlatform = "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9";
    }

    public readonly struct GameMode
    {
        public static string Unrated = "unrated";
        public static string Competitive = "competitive";
        public static string Spike_Rush = "spikerush";
        public static string Deathmatch = "deathmatch";
        public static string Escalation = "ggteam";
        public static string Replication = "onefa";
        public static string Snowball_Fight = "snowball";
        public static string Custom = "custom";
    }
}
