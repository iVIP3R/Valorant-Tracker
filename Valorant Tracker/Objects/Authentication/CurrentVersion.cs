using Newtonsoft.Json;
using System;

namespace Valorant_Tracker.Objects.Authentication
{
    public class CurrentVersion
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("data")]
        public data Data { get; set; }

        public class data
        {
            [JsonProperty("manifestId")]
            public string ManifestID { get; set; }

            [JsonProperty("branch")]
            public string Branch { get; set; }

            [JsonProperty("version")]
            public string Version { get; set; }

            [JsonProperty("buildVersion")]
            public string BuildVersion { get; set; }

            [JsonProperty("engineVersion")]
            public string EngineVersion { get; set; }

            [JsonProperty("riotClientVersion")]
            public string RiotClientVersion { get; set; }

            [JsonProperty("buildDate")]
            public DateTime BuildDate { get; set; }
        }
    }
}
