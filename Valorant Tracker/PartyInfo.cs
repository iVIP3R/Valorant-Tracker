using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Valorant_Tracker
{
    class PartyInfo
    {
        public string ID { get; set; }
        public string MUCName { get; set; }
        public string VoiceRoomID { get; set; }
        public long Version { get; set; }
        public string ClientVersion { get; set; }
        public List<Member> Members { get; set; }
        public string State { get; set; }
        public string PreviousState { get; set; }
        public string StateTransitionReason { get; set; }
        public string Accessibility { get; set; }
        public _CustomGameData CustomGameData { get; set; }
        public _MatchmakingData MatchmakingData { get; set; }
        public object Invites { get; set; }
        public List<object> Requests { get; set; }
        public string QueueEntryTime { get; set; }
        public _ErrorNotification ErrorNotification { get; set; }
        public int RestrictedSeconds { get; set; }
        public List<string> EligibleQueues { get; set; }
        public string PlatformType { get; set; }
        public List<object> QueueIneligibilities { get; set; }
        public _CheatData CheatData { get; set; }
        public List<object> XPBonuses { get; set; }
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

        public class _Ping
        {
            public int Ping { get; set; }
            public string GamePodID { get; set; }
        }

        public class Member
        {
            public string Subject { get; set; }
            public int CompetitiveTier { get; set; }
            public PlayerIdentity PlayerIdentity { get; set; }
            public object SeasonalBadgeInfo { get; set; }
            public bool IsOwner { get; set; }
            public int QueueEligibleRemainingGames { get; set; }
            public int QueueEligibleRemainingWins { get; set; }
            public List<_Ping> Pings { get; set; }
            public bool IsReady { get; set; }
            public bool IsModerator { get; set; }
            public bool UseBroadcastHUD { get; set; }
            public string PlatformType { get; set; }
        }

        public class Settings
        {
            public string Map { get; set; }
            public string Mode { get; set; }
            public bool UseBots { get; set; }
            public string GamePod { get; set; }
            public object GameRules { get; set; }
        }

        public class Membership
        {
            public object teamOne { get; set; }
            public object teamTwo { get; set; }
            public object teamSpectate { get; set; }
            public object teamOneCoaches { get; set; }
            public object teamTwoCoaches { get; set; }
        }

        public class _CustomGameData
        {
            public Settings Settings { get; set; }
            public Membership Membership { get; set; }
            public int MaxPartySize { get; set; }
            public bool AutobalanceEnabled { get; set; }
            public int AutobalanceMinPlayers { get; set; }
        }

        public class _MatchmakingData
        {
            public string QueueID { get; set; }
            public List<string> PreferredGamePods { get; set; }
        }

        public class _ErrorNotification
        {
            public string ErrorType { get; set; }
            public object ErroredPlayers { get; set; }
        }

        public class _CheatData
        {
            public string GamePodOverride { get; set; }
            public bool ForcePostGameProcessing { get; set; }
        }

        public static PartyInfo Get(Auth au, string PartyID)
        {
            PartyInfo Ret = new PartyInfo();
            string URL = "https://glz-" + au.Region + "-1." + au.Region + ".a.pvp.net/parties/v1/parties/" + PartyID;
            RestClient client = new RestClient(URL);
            client.CookieContainer = au.cookies;
            //client.CookieContainer = new CookieContainer();

            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {au.AccessToken}");
            request.AddHeader("X-Riot-Entitlements-JWT", $"{au.EntitlementToken}");
            request.AddHeader("X-Riot-ClientPlatform", $"{Info.ClientPlatform}");
            request.AddHeader("X-Riot-ClientVersion", $"{au.ClientVersion}");

            var Response = client.Execute(request);
            string ResponseContent = Response.Content;
            Ret = JsonConvert.DeserializeObject<PartyInfo>(ResponseContent);
            Ret.StatusCode = (int)Response.StatusCode;
            return Ret;
        }
    }
}
