using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
        public static async Task<AccountXP> GetDetailsAsync(Auth au)
        {
            var client = new RestClient($"https://pd.{au.RegionShard}.a.pvp.net/account-xp/v1/players/{au.Subject}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {au.AccessToken}");
            request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken);
            request.AddHeader("X-Riot-ClientPlatform", Info.ClientPlatform);
            request.AddHeader("X-Riot-ClientVersion", au.ClientVersion);

            var response = await client.ExecuteAsync(request);
            var ret = JsonConvert.DeserializeObject<AccountXP>(response.Content);

            if (ret != null)
                ret.StatusCode = (int)response.StatusCode;

            return ret ?? new AccountXP();
        }
    }
}