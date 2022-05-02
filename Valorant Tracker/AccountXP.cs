using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Valorant_Tracker
{
    class AccountXP
    {
        public class _Progress
        {
            public int Level { get; set; }
            public int XP { get; set; }
        }

        public class StartProgress
        {
            public int Level { get; set; }
            public int XP { get; set; }
        }

        public class EndProgress
        {
            public int Level { get; set; }
            public int XP { get; set; }
        }

        public class XPSource
        {
            public string ID { get; set; }
            public int Amount { get; set; }
        }

        public class _History
        {
            public string ID { get; set; }
            public DateTime MatchStart { get; set; }
            public StartProgress StartProgress { get; set; }
            public EndProgress EndProgress { get; set; }
            public int XPDelta { get; set; }
            public List<XPSource> XPSources { get; set; }
            public List<object> XPMultipliers { get; set; }
        }

        public int Version { get; set; }
        public string Subject { get; set; }
        public _Progress Progress { get; set; }
        public List<_History> History { get; set; }
        public string LastTimeGrantedFirstWin { get; set; }
        public string NextTimeFirstWinAvailable { get; set; }
        public int StatusCode;

        public static AccountXP GetDetails(Auth au)
        {
            AccountXP ret = new AccountXP();
            RestClient client = new RestClient("https://pd." + au.Region + ".a.pvp.net/account-xp/v1/players/" + au.Subject);
            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {au.AccessToken}");
            request.AddHeader("X-Riot-Entitlements-JWT", $"{au.EntitlementToken}");
            request.AddHeader("X-Riot-ClientPlatform", $"ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9");
            request.AddHeader("X-Riot-ClientVersion", $"{au.ClientVersion}");
            var Response = client.Execute(request);
            string ResponseContent = Response.Content;
            JObject obj = JObject.FromObject(JsonConvert.DeserializeObject(ResponseContent));
            ret = JsonConvert.DeserializeObject<AccountXP>(ResponseContent);
            ret.StatusCode = (int)Response.StatusCode;
            return ret;
        }

    }
}
