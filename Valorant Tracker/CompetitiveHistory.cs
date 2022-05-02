using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Valorant_Tracker
{
    class CompetitiveHistory
    {
        public int Version { get; set; }
        public string Subject { get; set; }
        public List<Match> Matches { get; set; }
        public string[] MatchesIDs;
        public int StatusCode;

        public class Match
        {
            public string MatchID { get; set; }
            public string MapID { get; set; }
            public string SeasonID { get; set; }
            public object MatchStartTime { get; set; }
            public int TierAfterUpdate { get; set; }
            public int TierBeforeUpdate { get; set; }
            public int RankedRatingAfterUpdate { get; set; }
            public int RankedRatingBeforeUpdate { get; set; }
            public int RankedRatingEarned { get; set; }
            public int RankedRatingPerformanceBonus { get; set; }
            public string CompetitiveMovement { get; set; }
            public int AFKPenalty { get; set; }
        }

        public static CompetitiveHistory Get(Auth au, GameMode GameMode)
        {
            CompetitiveHistory Ret = new CompetitiveHistory();
            string URL = " https://pd." + au.Region + ".a.pvp.net/mmr/v1/players/" + au.Subject + "/competitiveupdates?queue=" + GameMode;
            RestClient client = new RestClient(URL);
            client.CookieContainer = au.cookies;
            //client.CookieContainer = new CookieContainer();

            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {au.AccessToken}");
            request.AddHeader("X-Riot-Entitlements-JWT", $"{au.EntitlementToken}");
            request.AddHeader("X-Riot-ClientPlatform", $"{Info.ClientPlatform}");

            var Response = client.Execute(request);
            string ResponseContent = Response.Content;
            Ret = JsonConvert.DeserializeObject<CompetitiveHistory>(ResponseContent);
            Ret.MatchesIDs = new string[Ret.Matches.Count];
            for (int i = 0; i < Ret.Matches.Count; i++)
            {
                Ret.MatchesIDs[i] = Ret.Matches[i].MatchID;
            }
            Ret.StatusCode = (int)Response.StatusCode;
            return Ret;
        }
    }
}
