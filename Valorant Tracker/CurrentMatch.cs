using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Valorant_Tracker
{
    class CurrentMatch
    {
        public string MatchID { get; set; }
        public long Version { get; set; }
        public string State { get; set; }
        public string MapID { get; set; }
        public string ModeID { get; set; }
        public string ProvisioningFlow { get; set; }
        public string GamePodID { get; set; }
        public string AllMUCName { get; set; }
        public string TeamMUCName { get; set; }
        public string TeamVoiceID { get; set; }
        public bool IsReconnectable { get; set; }
        public _ConnectionDetails ConnectionDetails { get; set; }
        public object PostGameDetails { get; set; }
        public List<Player> Players { get; set; }
        public object MatchmakingData { get; set; }
        public int StatusCode;

        public class _ConnectionDetails
        {
            public string GameServerHost { get; set; }
            public int GameServerPort { get; set; }
            public int GameServerObfuscatedIP { get; set; }
            public int GameClientHash { get; set; }
            public string PlayerKey { get; set; }
            public string TempMap { get; set; }
            public string TempTeam { get; set; }
        }

        public class PlayerIdentity
        {
            public string Subject { get; set; }
            public string PlayerCardID { get; set; }
            public string PlayerTitleID { get; set; }
            public int AccountLevel { get; set; }
            public string PreferredLevelBorderID { get; set; }
            public bool Incognito { get; set; }
            public bool HideAccountLevel { get; set; }
        }

        public class SeasonalBadgeInfo
        {
            public string SeasonID { get; set; }
            public int NumberOfWins { get; set; }
            public object WinsByTier { get; set; }
            public int Rank { get; set; }
            public int LeaderboardRank { get; set; }
        }

        public class Player
        {
            public string Subject { get; set; }
            public string TeamID { get; set; }
            public string CharacterID { get; set; }
            public PlayerIdentity PlayerIdentity { get; set; }
            public SeasonalBadgeInfo SeasonalBadgeInfo { get; set; }
            public bool IsCoach { get; set; }
        }

        public static CurrentMatch Get(Auth au, string MatchID)
        {
            CurrentMatch Ret = new CurrentMatch();
            string URL = "https://glz-" + au.Region + "-1." + au.Region + ".a.pvp.net/core-game/v1/matches/" + MatchID;
            RestClient client = new RestClient(URL);
            client.CookieContainer = au.cookies;
            //client.CookieContainer = new CookieContainer();

            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {au.AccessToken}");
            request.AddHeader("X-Riot-Entitlements-JWT", $"{au.EntitlementToken}");

            var Response = client.Execute(request);
            string ResponseContent = Response.Content;
            Ret = JsonConvert.DeserializeObject<CurrentMatch>(ResponseContent);
            Ret.StatusCode = (int)Response.StatusCode;
            return Ret;
        }
    }
}
