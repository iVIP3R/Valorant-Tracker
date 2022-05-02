using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Valorant_Tracker
{
    class Rank
    {
        public string SeasonID { get; set; }
        public int NumberOfGames { get; set; }
        public int NumberOfWins { get; set; }
        public int NumberOfPlacemenstsWins { get; set; }
        public int NumberOfWinsWithPlacements { get; set; }
        public int NumberOfLoses { get; set; }
        //public int NumberOfPlacementLoses { get; set; }
        public string WinRatio { get; set; }
        public int rank { get; set; }
        public string RankFormatted { get; set; }
        public int CapstoneWins { get; set; }
        public int LeaderboardRank { get; set; }
        public int CompetitiveTier { get; set; }
        public int RankedRating { get; set; }
        public int GamesNeededForRating { get; set; }
        public int TotalWinsNeededForRank { get; set; }
        public int StatusCode { get; set; }

        private static string GetRankFormatted(int Rank)
        {
            string[] Ranks = new string[] { "Unranked", "", "", "Iron 1", "Iron 2", "Iron 3", "Bronze 1", "Bronze 2", "Bronze 3", "Silver 1", "Silver 2", "Silver 3", "Gold 1", "Gold 2", "Gold 3", "Platinum 1", "Platinum 2", "Platinum 3", "Diamond 1", "Diamond 2", "Diamond 3", "Immortal 1", "Immortal 2", "Immortal 3", "Radiant" };
            return Ranks[Rank];
        }

        public static Rank GetDetails (Auth au, string GameMode, string SeasonID)
        {
            Rank Ret = new Rank();
            RestClient Client = new RestClient(new Uri($"https://pd.eu.a.pvp.net/mmr/v1/players/{au.Subject}"));
            RestRequest Request = new RestRequest(Method.GET);
            Request.AddHeader("Authorization", $"Bearer {au.AccessToken}");
            Request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken);
            Request.AddHeader("X-Riot-ClientPlatform", Info.ClientPlatform);
            Request.AddHeader("X-Riot-ClientVersion", au.ClientVersion);
            var Respnse = Client.Execute(Request);
            string ResponseContent = Client.Execute(Request).Content;
            JObject obj = JObject.FromObject(JsonConvert.DeserializeObject(ResponseContent));
            //string Season = obj["LatestCompetitiveUpdate"].Value<string>("SeasonID");
            foreach (JProperty Seasons in obj["QueueSkills"][GameMode]["SeasonalInfoBySeasonID"].Value<JToken>())
            {
                if (SeasonID == Seasons.Name)
                    {
                        Ret.SeasonID = obj["QueueSkills"][GameMode]["SeasonalInfoBySeasonID"][SeasonID].Value<string>("SeasonID");
                        Ret.NumberOfGames = obj["QueueSkills"][GameMode]["SeasonalInfoBySeasonID"][SeasonID].Value<int>("NumberOfGames");
                        Ret.NumberOfWins = obj["QueueSkills"][GameMode]["SeasonalInfoBySeasonID"][SeasonID].Value<int>("NumberOfWins");
                        Ret.NumberOfPlacemenstsWins = Ret.NumberOfWinsWithPlacements - Ret.NumberOfWins;
                        Ret.NumberOfWinsWithPlacements = obj["QueueSkills"][GameMode]["SeasonalInfoBySeasonID"][SeasonID].Value<int>("NumberOfWinsWithPlacements");
                        Ret.NumberOfLoses = Ret.NumberOfGames - Ret.NumberOfWinsWithPlacements;
                        //Ret.NumberOfPlacementLoses = (int)(5 - (Ret.NumberOfWinsWithPlacements - Ret.NumberOfWins));
                        Ret.WinRatio = (((decimal)Ret.NumberOfWinsWithPlacements / (decimal)Ret.NumberOfGames) * 100).ToString("0.0") + "%";
                        Ret.rank = obj["QueueSkills"][GameMode]["SeasonalInfoBySeasonID"][SeasonID].Value<int>("Rank");
                        Ret.CapstoneWins = obj["QueueSkills"][GameMode]["SeasonalInfoBySeasonID"][SeasonID].Value<int>("CapstoneWins");
                        Ret.LeaderboardRank = obj["QueueSkills"][GameMode]["SeasonalInfoBySeasonID"][SeasonID].Value<int>("LeaderboardRank");
                        Ret.CompetitiveTier = obj["QueueSkills"][GameMode]["SeasonalInfoBySeasonID"][SeasonID].Value<int>("CompetitiveTier");
                        Ret.RankFormatted = GetRankFormatted(Ret.CompetitiveTier);
                        Ret.RankedRating = obj["QueueSkills"][GameMode]["SeasonalInfoBySeasonID"][SeasonID].Value<int>("RankedRating");
                        Ret.GamesNeededForRating = obj["QueueSkills"][GameMode]["SeasonalInfoBySeasonID"][SeasonID].Value<int>("GamesNeededForRating");
                        Ret.TotalWinsNeededForRank = obj["QueueSkills"][GameMode]["SeasonalInfoBySeasonID"][SeasonID].Value<int>("TotalWinsNeededForRank");
                        Ret.StatusCode = (int)Respnse.StatusCode;
                    break;
                    }
                    else
                    {
                        Ret.SeasonID = SeasonID;
                        Ret.NumberOfGames = 0;
                        Ret.NumberOfWins = 0;
                        Ret.NumberOfPlacemenstsWins = 0;
                        Ret.NumberOfWinsWithPlacements = 0;
                        Ret.NumberOfLoses = 0;
                        //Ret.NumberOfPlacementLoses = 0;
                        Ret.WinRatio = 0 + "%";
                        Ret.rank = 0;
                        Ret.RankFormatted = GetRankFormatted(Ret.CompetitiveTier);
                        Ret.CapstoneWins = 0;
                        Ret.LeaderboardRank = 0;
                        Ret.CompetitiveTier = 0;
                        Ret.RankedRating = 0;
                        Ret.GamesNeededForRating = 0;
                        Ret.TotalWinsNeededForRank = 0;
                        Ret.StatusCode = (int)Respnse.StatusCode;
                    }
            }
            return Ret;
        }
    }
}
