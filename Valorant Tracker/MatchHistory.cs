using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public int StatusCode;

        public class _History
        {
            public string MatchID { get; set; }
            public object GameStartTime { get; set; }
            public string TeamID { get; set; }
        }

        public static MatchHistory Get(Auth au, string GameMode)
        {
            MatchHistory Ret = new MatchHistory();
            string URL = " https://pd." + au.Region + ".a.pvp.net/match-history/v1/history/" + au.Subject + "?queue=" + GameMode;
            RestClient client = new RestClient(URL);
            client.CookieContainer = au.cookies;
            //client.CookieContainer = new CookieContainer();

            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {au.AccessToken}");
            request.AddHeader("X-Riot-Entitlements-JWT", $"{au.EntitlementToken}");
            request.AddHeader("X-Riot-ClientPlatform", $"{Info.ClientPlatform}");

            var Response = client.Execute(request);
            string ResponseContent = Response.Content;
            Ret = JsonConvert.DeserializeObject<MatchHistory>(ResponseContent);  
            Ret.StatusCode = (int)Response.StatusCode;
            return Ret;
        }

        public static MatchHistory RetrieveIDs(Auth au, int MatchesCount, string GameMode)
        {
            decimal Iteration = (decimal)MatchesCount / 20;
            int startIndex = 0;
            int endIndex = 20;
            List<string> _IDs = new List<string>();
            MatchHistory Ret = new MatchHistory();
            for (int i = 0; i < (Math.Ceiling(Iteration)); i++)
            {
                string URL = $"https://pd.{au.Region}.a.pvp.net/match-history/v1/history/{au.Subject}?startIndex={startIndex}&endIndex={endIndex}&queue={GameMode}";
                RestClient client = new RestClient(URL);
                client.CookieContainer = au.cookies;
                //client.CookieContainer = new CookieContainer();

                RestRequest request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", $"Bearer {au.AccessToken}");
                request.AddHeader("X-Riot-Entitlements-JWT", $"{au.EntitlementToken}");
                request.AddHeader("X-Riot-ClientPlatform", $"{Info.ClientPlatform}");

                var Response = client.Execute(request);
                string ResponseContent = Response.Content;
                Ret = JsonConvert.DeserializeObject<MatchHistory>(ResponseContent);
                Ret.StatusCode = (int)Response.StatusCode;
                foreach (var item in Ret.History)
                {
                    _IDs.Add(item.MatchID);
                }
                startIndex += 20;
                endIndex += 20;
            }
            Ret.IDs = _IDs;
            return Ret;
        }
    }
}
