using Newtonsoft.Json;
using System.Collections.Generic;

namespace Valorant_Tracker.Objects.Player
{
    public class MMR
    {
        public long Version { get; set; }
        public string Subject { get; set; }
        public bool NewPlayerExperienceFinished { get; set; }
        [JsonProperty("QueueSkills")]
        public QueueSkills QueueData { get; set; }
        public CompetitiveUpdate LatestCompetitiveUpdate { get; set; }
        public bool IsLeaderboardAnonymized { get; set; }
        public bool IsActRankBadgeHidden { get; set; }

        public class QueueSkills
        {
            public Competitive competitive { get; set; }
            public Custom custom { get; set; }
            public Deathmatch deathmatch { get; set; }
            public Ggteam ggteam { get; set; }
            public Newmap newmap { get; set; }
            public Onefa onefa { get; set; }
            public Seeding seeding { get; set; }
            public Spikerush spikerush { get; set; }
            public Unrated unrated { get; set; }
        }

        public class Custom
        {
            public int TotalGamesNeededForRating { get; set; }
            public int TotalGamesNeededForLeaderboard { get; set; }
            public int CurrentSeasonGamesNeededForRating { get; set; }
            public SeasonalInfoBySeasonID SeasonalInfoBySeasonID { get; set; }
        }

        public class Deathmatch
        {
            public int TotalGamesNeededForRating { get; set; }
            public int TotalGamesNeededForLeaderboard { get; set; }
            public int CurrentSeasonGamesNeededForRating { get; set; }
            public SeasonalInfoBySeasonID SeasonalInfoBySeasonID { get; set; }
        }

        public class Ggteam
        {
            public int TotalGamesNeededForRating { get; set; }
            public int TotalGamesNeededForLeaderboard { get; set; }
            public int CurrentSeasonGamesNeededForRating { get; set; }
            public SeasonalInfoBySeasonID SeasonalInfoBySeasonID { get; set; }
        }

        public class Newmap
        {
            public int TotalGamesNeededForRating { get; set; }
            public int TotalGamesNeededForLeaderboard { get; set; }
            public int CurrentSeasonGamesNeededForRating { get; set; }
            public SeasonalInfoBySeasonID SeasonalInfoBySeasonID { get; set; }
        }

        public class Onefa
        {
            public int TotalGamesNeededForRating { get; set; }
            public int TotalGamesNeededForLeaderboard { get; set; }
            public int CurrentSeasonGamesNeededForRating { get; set; }
            public SeasonalInfoBySeasonID SeasonalInfoBySeasonID { get; set; }
        }

        public class Seeding
        {
            public int TotalGamesNeededForRating { get; set; }
            public int TotalGamesNeededForLeaderboard { get; set; }
            public int CurrentSeasonGamesNeededForRating { get; set; }
            public SeasonalInfoBySeasonID SeasonalInfoBySeasonID { get; set; }
        }

        public class Spikerush
        {
            public int TotalGamesNeededForRating { get; set; }
            public int TotalGamesNeededForLeaderboard { get; set; }
            public int CurrentSeasonGamesNeededForRating { get; set; }
            public SeasonalInfoBySeasonID SeasonalInfoBySeasonID { get; set; }
        }

        public class Unrated
        {
            public int TotalGamesNeededForRating { get; set; }
            public int TotalGamesNeededForLeaderboard { get; set; }
            public int CurrentSeasonGamesNeededForRating { get; set; }
            public SeasonalInfoBySeasonID SeasonalInfoBySeasonID { get; set; }
        }

        public class Competitive
        {
            public int TotalGamesNeededForRating { get; set; }
            public int TotalGamesNeededForLeaderboard { get; set; }
            public int CurrentSeasonGamesNeededForRating { get; set; }
            public SeasonalInfoBySeasonID SeasonalInfoBySeasonID { get; set; }
        }

        public class ActInformation
        {
            public string SeasonID { get; set; }
            public int NumberOfWins { get; set; }
            public int NumberOfWinsWithPlacements { get; set; }
            public int NumberOfGames { get; set; }
            public int Rank { get; set; }
            public int CapstoneWins { get; set; }
            public int LeaderboardRank { get; set; }
            public int CompetitiveTier { get; set; }
            public int RankedRating { get; set; }
            public Dictionary<int, int> WinsByTier { get; set; }
            public int GamesNeededForRating { get; set; }
            public int TotalWinsNeededForRank { get; set; }
        }

        public class SeasonalInfoBySeasonID
        {
            [JsonProperty("2a27e5d2-4d30-c9e2-b15a-93b8909a442c")]
            public ActInformation _2a27e5d24d30C9e2B15a93b8909a442c { get; set; }

            [JsonProperty("3e47230a-463c-a301-eb7d-67bb60357d4f")]
            public ActInformation _3e47230a463cA301Eb7d67bb60357d4f { get; set; }

            [JsonProperty("4cb622e1-4244-6da3-7276-8daaf1c01be2")]
            public ActInformation _4cb622e142446da372768daaf1c01be2 { get; set; }

            [JsonProperty("52e9749a-429b-7060-99fe-4595426a0cf7")]
            public ActInformation _52e9749a429b706099fe4595426a0cf7 { get; set; }

            [JsonProperty("573f53ac-41a5-3a7d-d9ce-d6a6298e5704")]
            public ActInformation _573f53ac41a53a7dD9ceD6a6298e5704 { get; set; }

            [JsonProperty("67e373c7-48f7-b422-641b-079ace30b427")]
            public ActInformation _67e373c748f7B422641b079ace30b427 { get; set; }

            [JsonProperty("a16955a5-4ad0-f761-5e9e-389df1c892fb")]
            public ActInformation A16955a54ad0F7615e9e389df1c892fb { get; set; }

            [JsonProperty("d929bc38-4ab6-7da4-94f0-ee84f8ac141e")]
            public ActInformation D929bc384ab67da494f0Ee84f8ac141e { get; set; }
        }

        public class CompetitiveUpdate
        {
            public string MatchID { get; set; }
            public string MapID { get; set; }
            public string SeasonID { get; set; }
            public long MatchStartTime { get; set; }
            public int TierAfterUpdate { get; set; }
            public int TierBeforeUpdate { get; set; }
            public int RankedRatingAfterUpdate { get; set; }
            public int RankedRatingBeforeUpdate { get; set; }
            public int RankedRatingEarned { get; set; }
            public int RankedRatingPerformanceBonus { get; set; }
            public string CompetitiveMovement { get; set; }
            public int AFKPenalty { get; set; }
        }
    }
}
