using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace Valorant_Tracker
{
    class MatchHistory
    {
        public string Subject { get; set; }
        public int BeginIndex { get; set; }
        public int EndIndex { get; set; }
        public int Total { get; set; }
        public List<_History> History { get; set; }
        public List<string> IDs = new List<string>();
        public List<_History> Histories = new List<_History>();
        public int StatusCode;

        public class _History
        {
            public string MatchID { get; set; }
            public object GameStartTime { get; set; }
            public string TeamID { get; set; }
        }

        public static MatchHistory Get(Auth au, string GameMode)
        {
            string url = $"https://pd.{au.RegionShard}.a.pvp.net/match-history/v1/history/{au.Subject}?queue={GameMode}";
            var client = new RestClient(url);
            client.CookieContainer = au.cookies;

            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {au.AccessToken}");
            request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken);
            request.AddHeader("X-Riot-ClientPlatform", Info.ClientPlatform);
            request.AddHeader("X-Riot-ClientVersion", au.ClientVersion);

            var response = client.Execute(request);

            var ret = JsonConvert.DeserializeObject<MatchHistory>(response.Content) ?? new MatchHistory();
            ret.StatusCode = (int)response.StatusCode;
            if (ret.History == null) ret.History = new List<_History>();

            return ret;
        }

        public static MatchHistory RetrieveIDs(Auth au, int MatchesCount, string GameMode)
        {
            if (MatchesCount <= 0)
                return new MatchHistory { IDs = new List<string>() };

            decimal Iteration = (decimal)MatchesCount / 20;
            int startIndex = 0;
            int endIndex = 20;
            MatchHistory Ret = new MatchHistory();

            for (int i = 0; i < (Math.Ceiling(Iteration)); i++)
            {
                string url = $"https://pd.{au.RegionShard}.a.pvp.net/match-history/v1/history/{au.Subject}?startIndex={startIndex}&endIndex={endIndex}&queue={GameMode}";
                var client = new RestClient(url);
                client.CookieContainer = au.cookies;

                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", $"Bearer {au.AccessToken}");
                request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken);
                request.AddHeader("X-Riot-ClientPlatform", Info.ClientPlatform);
                request.AddHeader("X-Riot-ClientVersion", au.ClientVersion);

                var response = client.Execute(request);
                var page = JsonConvert.DeserializeObject<MatchHistory>(response.Content);

                if (page?.History != null)
                {
                    foreach (var item in page.History)
                    {
                        if (!string.IsNullOrEmpty(item.MatchID))
                        {
                            Ret.IDs.Add(item.MatchID);
                            Ret.Histories.Add(item);
                        }
                    }
                }

                startIndex += 20;
                endIndex += 20;
            }
            return Ret;
        }
    }
}