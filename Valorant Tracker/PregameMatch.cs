using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Valorant_Tracker
{
    class PregameMatch
    {
        public string ID { get; set; }
        public long Version { get; set; }
        public List<Team> Teams { get; set; }
        public _AllyTeam AllyTeam { get; set; }
        public object EnemyTeam { get; set; }
        public List<object> ObserverSubjects { get; set; }
        public List<object> MatchCoaches { get; set; }
        public int EnemyTeamSize { get; set; }
        public int EnemyTeamLockCount { get; set; }
        public string PregameState { get; set; }
        public DateTime LastUpdated { get; set; }
        public string MapID { get; set; }
        public string GamePodID { get; set; }
        public string Mode { get; set; }
        public string VoiceSessionID { get; set; }
        public string MUCName { get; set; }
        public string QueueID { get; set; }
        public string ProvisioningFlowID { get; set; }
        public bool IsRanked { get; set; }
        public long PhaseTimeRemainingNS { get; set; }
        public bool altModesFlagADA { get; set; }
        public int StatusCode;

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
            public string CharacterID { get; set; }
            public string CharacterSelectionState { get; set; }
            public string PregamePlayerState { get; set; }
            public int CompetitiveTier { get; set; }
            public PlayerIdentity PlayerIdentity { get; set; }
            public SeasonalBadgeInfo SeasonalBadgeInfo { get; set; }
        }

        public class Team
        {
            public string TeamID { get; set; }
            public List<Player> Players { get; set; }
        }

        public class _AllyTeam
        {
            public string TeamID { get; set; }
            public List<Player> Players { get; set; }
        }

        public static PregameMatch Get(Auth au, string MatchID)
        {
            PregameMatch Ret = new PregameMatch();
            string URL = "https://glz-" + au.Region + "-1." + au.Region + ".a.pvp.net/pregame/v1/matches/" + MatchID;
            RestClient client = new RestClient(URL);
            client.CookieContainer = au.cookies;
            //client.CookieContainer = new CookieContainer();

            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {au.AccessToken}");
            request.AddHeader("X-Riot-Entitlements-JWT", $"{au.EntitlementToken}");

            var Response = client.Execute(request);
            string ResponseContent = Response.Content;
            Ret = JsonConvert.DeserializeObject<PregameMatch>(ResponseContent);
            Ret.StatusCode = (int)Response.StatusCode;
            return Ret;
        }

    }
}
