using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using RestSharp;

namespace Valorant_Tracker
{
    class MatchDetails
    {
        public MatchInfo matchInfo { get; set; }
        public List<Player> players { get; set; }
        public List<object> bots { get; set; }
        public List<object> coaches { get; set; }
        public List<Team> teams { get; set; }
        public List<RoundResult> roundResults { get; set; }
        public List<Kill> kills { get; set; }
        public List<_Details> Details;
        public List<_MatchOverview> MatchOverview;
        public int StatusCode;

        public class _Details
        {
            public string Server;
            public string Map;
            public string MatchLength;
            public DateTime MatchStartTime;
            public string Agent;
            public string Score;
            public string KDA;
            public string KD;
            public string HS;
            public string ADR;
            public int Plants;
            public int Defuses;
            public int FirstBloods;
            public int EconRating;
            public string AverageCombatScore;
        }

        public class _MatchOverview
        {
            public string IDs;
            public string Agents;
            public string Names;
            public decimal AverageCombatScores;
            public string KDAs;
            public decimal KDs;
            public int isPositive;
            public string ADRs;
            public string HSs;
            public int TotalRounds;
            public int FirstBloods;
            public int EconRatings;
            public int Plants;
            public int Defuses;
        }

        public class MatchInfo
        {
            public string matchId { get; set; }
            public string mapId { get; set; }
            public string gamePodId { get; set; }
            public string gameLoopZone { get; set; }
            public string gameServerAddress { get; set; }
            public string gameVersion { get; set; }
            public double gameLengthMillis { get; set; }
            public long gameStartMillis { get; set; }
            public string provisioningFlowID { get; set; }
            public bool isCompleted { get; set; }
            public string customGameName { get; set; }
            public bool forcePostProcessing { get; set; }
            public string queueID { get; set; }
            public string gameMode { get; set; }
            public bool isRanked { get; set; }
            public bool canProgressContracts { get; set; }
            public bool isMatchSampled { get; set; }
            public string seasonId { get; set; }
            public string completionState { get; set; }
            public string platformType { get; set; }
        }

        public class PlatformInfo
        {
            public string platformType { get; set; }
            public string platformOS { get; set; }
            public string platformOSVersion { get; set; }
            public string platformChipset { get; set; }
        }

        public class AbilityCasts
        {
            public int grenadeCasts { get; set; }
            public int ability1Casts { get; set; }
            public int ability2Casts { get; set; }
            public int ultimateCasts { get; set; }
        }

        public class Stats
        {
            public int score { get; set; }
            public int roundsPlayed { get; set; }
            public int kills { get; set; }
            public int deaths { get; set; }
            public int assists { get; set; }
            public int playtimeMillis { get; set; }
            public AbilityCasts abilityCasts { get; set; }
        }

        public class RoundDamage
        {
            public int round { get; set; }
            public string receiver { get; set; }
            public int damage { get; set; }
        }

        public class BehaviorFactors
        {
            public double afkRounds { get; set; }
            public double stayedInSpawnRounds { get; set; }
        }

        public class BasicMovement
        {
            public int idleTimeMillis { get; set; }
            public int objectiveCompleteTimeMillis { get; set; }
        }

        public class BasicGunSkill
        {
            public int idleTimeMillis { get; set; }
            public int objectiveCompleteTimeMillis { get; set; }
        }

        public class AdaptiveBots
        {
            public int idleTimeMillis { get; set; }
            public int objectiveCompleteTimeMillis { get; set; }
            public int adaptiveBotAverageDurationMillisAllAttempts { get; set; }
            public int adaptiveBotAverageDurationMillisFirstAttempt { get; set; }
            public object killDetailsFirstAttempt { get; set; }
        }

        public class Ability
        {
            public int idleTimeMillis { get; set; }
            public int objectiveCompleteTimeMillis { get; set; }
            public object grenadeEffects { get; set; }
            public object ability1Effects { get; set; }
            public object ability2Effects { get; set; }
            public object ultimateEffects { get; set; }
        }

        public class BombPlant
        {
            public int idleTimeMillis { get; set; }
            public int objectiveCompleteTimeMillis { get; set; }
        }

        public class DefendBombSite
        {
            public int idleTimeMillis { get; set; }
            public int objectiveCompleteTimeMillis { get; set; }
            public bool success { get; set; }
        }

        public class SettingStatus
        {
            public bool isMouseSensitivityDefault { get; set; }
            public bool isCrosshairDefault { get; set; }
        }

        public class NewPlayerExperienceDetails
        {
            public BasicMovement basicMovement { get; set; }
            public BasicGunSkill basicGunSkill { get; set; }
            public AdaptiveBots adaptiveBots { get; set; }
            public Ability ability { get; set; }
            public BombPlant bombPlant { get; set; }
            public DefendBombSite defendBombSite { get; set; }
            public SettingStatus settingStatus { get; set; }
        }

        public class Player
        {
            public string subject { get; set; }
            public string gameName { get; set; }
            public string tagLine { get; set; }
            public PlatformInfo platformInfo { get; set; }
            public string teamId { get; set; }
            public string partyId { get; set; }
            public string characterId { get; set; }
            public Stats stats { get; set; }
            public List<RoundDamage> roundDamage { get; set; }
            public int competitiveTier { get; set; }
            public string playerCard { get; set; }
            public string playerTitle { get; set; }
            public int accountLevel { get; set; }
            public int sessionPlaytimeMinutes { get; set; }
            public BehaviorFactors behaviorFactors { get; set; }
            public NewPlayerExperienceDetails newPlayerExperienceDetails { get; set; }
        }

        public class Team
        {
            public string teamId { get; set; }
            public bool won { get; set; }
            public int roundsPlayed { get; set; }
            public int roundsWon { get; set; }
            public int numPoints { get; set; }
        }

        public class PlantLocation
        {
            public int x { get; set; }
            public int y { get; set; }
        }

        public class DefuseLocation
        {
            public int x { get; set; }
            public int y { get; set; }
        }

        public class VictimLocation
        {
            public int x { get; set; }
            public int y { get; set; }
        }

        public class FinishingDamage
        {
            public string damageType { get; set; }
            public string damageItem { get; set; }
            public bool isSecondaryFireMode { get; set; }
        }

        public class Kill
        {
            public int gameTime { get; set; }
            public int roundTime { get; set; }
            public string killer { get; set; }
            public string victim { get; set; }
            public VictimLocation victimLocation { get; set; }
            public List<string> assistants { get; set; }
            public List<object> playerLocations { get; set; }
            public FinishingDamage finishingDamage { get; set; }
            public int round { get; set; }
        }

        public class Damage
        {
            public string receiver { get; set; }
            public int damage { get; set; }
            public int legshots { get; set; }
            public int bodyshots { get; set; }
            public int headshots { get; set; }
        }

        public class Economy
        {
            public int loadoutValue { get; set; }
            public string weapon { get; set; }
            public string armor { get; set; }
            public int remaining { get; set; }
            public int spent { get; set; }
        }

        public class PlayerStat
        {
            public string subject { get; set; }
            public List<Kill> kills { get; set; }
            public List<Damage> damage { get; set; }
            public int score { get; set; }
            public Economy economy { get; set; }
            public Ability ability { get; set; }
            public bool wasAfk { get; set; }
            public bool wasPenalized { get; set; }
            public bool stayedInSpawn { get; set; }
        }

        public class PlayerEconomy
        {
            public string subject { get; set; }
            public int loadoutValue { get; set; }
            public string weapon { get; set; }
            public string armor { get; set; }
            public int remaining { get; set; }
            public int spent { get; set; }
        }

        public class PlayerScore
        {
            public string subject { get; set; }
            public int score { get; set; }
        }

        public class RoundResult
        {
            public int roundNum { get; set; }
            public string roundResult { get; set; }
            public string roundCeremony { get; set; }
            public string winningTeam { get; set; }
            public string bombPlanter { get; set; }
            public string bombDefuser { get; set; }
            public int plantRoundTime { get; set; }
            public List<object> plantPlayerLocations { get; set; }
            public PlantLocation plantLocation { get; set; }
            public string plantSite { get; set; }
            public int defuseRoundTime { get; set; }
            public List<object> defusePlayerLocations { get; set; }
            public DefuseLocation defuseLocation { get; set; }
            public List<PlayerStat> playerStats { get; set; }
            public string roundResultCode { get; set; }
            public List<PlayerEconomy> playerEconomies { get; set; }
            public List<PlayerScore> playerScores { get; set; }
        }

        public static MatchDetails Get(Auth au, string MatchID)
        {
            MatchDetails Ret = new MatchDetails();
            string URL = " https://pd." + au.Region + ".a.pvp.net/match-details/v1/matches/" + MatchID;
            RestClient client = new RestClient(URL);
            client.CookieContainer = au.cookies;
            //client.CookieContainer = new CookieContainer();

            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {au.AccessToken}");
            request.AddHeader("X-Riot-Entitlements-JWT", $"{au.EntitlementToken}");

            var Response = client.Execute(request);
            string ResponseContent = Response.Content;
            Ret = JsonConvert.DeserializeObject<MatchDetails>(ResponseContent);
            Ret.Details = new List<_Details>();
            Ret.MatchOverview = new List<_MatchOverview>();
            _Details details = new _Details();
            _MatchOverview matchOverview = new _MatchOverview();
            //string Server = "N/A";
            //string MatchLength = "N/A";
            //DateTime MatchStartTime;
            //string Agent = "N/A";
            //string Score = "N/A";
            //string KDA = "N/A";
            //string KD = "N/A";
            //string HS = "N/A";
            //string ADR = "N/A";
            //int Kill = 0;
            //string AverageCombatScore = "N/A";

            #region Details

            #region Map
            switch (Ret.matchInfo.mapId)
            {
                case "/Game/Maps/Ascent/Ascent":
                    details.Map = "Ascent";
                    break;
                case "/Game/Maps/Bonsai/Bonsai":
                    details.Map = "Split";
                    break;
                case "/Game/Maps/Duality/Duality":
                    details.Map = "Bind";
                    break;
                case "/Game/Maps/Foxtrot/Foxtrot":
                    details.Map = "Breeze";
                    break;
                case "/Game/Maps/Port/Port":
                    details.Map = "Icebox";
                    break;
                case "/Game/Maps/Triad/Triad":
                    details.Map = "Haven";
                    break;
                case "/Game/Maps/Canyon/Canyon":
                    details.Map = "Fracture";
                    break;
            }
            #endregion

            #region Server
            switch (Ret.matchInfo.gamePodId)
            {
                // EU
                case "aresriot.aws-rclusterprod-euw3-1.eu-gp-paris-1":
                    details.Server = "Paris 1";
                    break;
                case "aresriot.aws-rclusterprod-euw3-1.eu-gp-paris-awsedge-1":
                    details.Server = "Paris 2";
                    break;
                case "aresriot.aws-rclusterprod-euc1-1.eu-gp-frankfurt-1":
                    details.Server = "Frankfurt 1";
                    break;
                case "aresriot.aws-rclusterprod-euc1-1.eu-gp-frankfurt-awsedge-1":
                    details.Server = "Frankfurt 2";
                    break;
                case "aresriot.aws-rclusterprod-euw2-1.eu-gp-london-awsedge-1":
                    details.Server = "London";
                    break;
                case "aresriot.aws-rclusterprod-waw1-1.eu-gp-warsaw-1":
                    details.Server = "Warsaw";
                    break;
                case "aresriot.aws-rclusterprod-eun1-1.eu-gp-stockholm-1":
                    details.Server = "Stockholm 1";
                    break;
                case "aresriot.aws-rclusterprod-mad1-1.eu-gp-madrid-1":
                    details.Server = "Madrid";
                    break;
                case "aresriot.mtl-riot-ist1-2.eu-gp-istanbul-1":
                    details.Server = "Istanbul";
                    break;
                case "aresriot.aws-rclusterprod-mes1-1.eu-gp-bahrain-awsedge-1":
                    details.Server = "Bahrain";
                    break;
                case "aresriot.aws-rclusterprod-apne1-1.eu-gp-tokyo-1":
                    details.Server = "Tokyo";
                    break;
                // NA
                case "aresriot.aws-rclusterprod-atl1-1.na-gp-atlanta-1":
                    details.Server = "US Central (Georgia)";
                    break;
                case "aresriot.mtl-riot-ord2-3.na-gp-chicago-1":
                    details.Server = "US Central (Illinois)";
                    break;
                case "aresriot.aws-rclusterprod-dfw1-1.na-gp-dallas-1":
                    details.Server = "US Central (Texas)";
                    break;
                case "aresriot.aws-rclusterprod-use1-1.na-gp-ashburn-1":
                    details.Server = "US East (N. Virginia 1)";
                    break;
                case "aresriot.aws-rclusterprod-use1-1.na-gp-ashburn-awsedge-1":
                    details.Server = "US East (N. Virginia 2)";
                    break;
                case "aresriot.aws-rclusterprod-usw2-1.na-gp-oregon-1":
                    details.Server = "US West (Oregon 1)";
                    break;
                case "aresriot.aws-rclusterprod-usw1-1.na-gp-norcal-1":
                    details.Server = "US West (N. California 1)";
                    break;
                case "aresriot.aws-rclusterprod-usw1-1.na-gp-norcal-awsedge-1":
                    details.Server = "US West (N. California 2)";
                    break;
                // AP
                case "aresriot.aws-rclusterprod-aps1-1.ap-gp-mumbai-awsedge-1":
                    details.Server = "Mumbai";
                    break;
                case "aresriot.aws-rclusterprod-apse1-1.ap-gp-singapore-1":
                    details.Server = "Singapore 1";
                    break;
                case "aresriot.aws-rclusterprod-apse1-1.ap-gp-singapore-awsedge-1":
                    details.Server = "Singapore 2";
                    break;
                case "aresriot.aws-rclusterprod-ape1-1.ap-gp-hongkong-1":
                    details.Server = "Hong Kong 1";
                    break;
                case "aresriot.aws-rclusterprod-ape1-1.ap-gp-hongkong-awsedge-1":
                    details.Server = "Hong Kong 2";
                    break;
                case "aresriot.aws-rclusterprod-apne1-1.ap-gp-tokyo-1":
                    details.Server = "Tokyo 1";
                    break;
                case "aresriot.aws-rclusterprod-apne1-1.ap-gp-tokyo-awsedge-1":
                    details.Server = "Tokyo 2";
                    break;
                case "aresriot.aws-rclusterprod-apse2-1.ap-gp-sydney-1":
                    details.Server = "Sydney 1";
                    break;
                case "aresriot.aws-rclusterprod-apse2-1.ap-gp-sydney-awsedge-1":
                    details.Server = "Sydney 2";
                    break;
                // KR
                case "aresriot.aws-rclusterprod-apne2-1.kr-gp-seoul-1":
                    details.Server = "Seoul 1";
                    break;
                case "aresriot.aws-rclusterprod-apne2-1.kr-gp-seoul-awsedge-1":
                    details.Server = "Seoul 2";
                    break;
                // LATAM
                case "aresriot.mtl-ctl-scl2-2.latam-gp-santiago-1":
                    details.Server = "Santiago";
                    break;
                case "aresriot.mtl-tmx-mex1-1.latam-gp-mexicocity-1":
                    details.Server = "Mexico City";
                    break;
                case "aresriot.mia1.latam-gp-miami-1":
                    details.Server = "Miami";
                    break;
                // BR
                case "aresriot.aws-rclusterprod-sae1-1.br-gp-saopaulo-1":
                    details.Server = "Sao Paulo 1";
                    break;
                case "aresriot.aws-rclusterprod-sae1-1.br-gp-saopaulo-awsedge-1":
                    details.Server = "Sao Paulo 2";
                    break;
            }
            #endregion

            #region Agent
            foreach (var Player in Ret.players)
            {
                if (Player.subject == au.Subject)
                {
                    details.Agent = ConvertToAgent(Player.characterId);
                }
            }
            #endregion

            #region Match length
            details.MatchLength = TimeSpan.FromMilliseconds(Ret.matchInfo.gameLengthMillis).ToString(@"hh\:mm\:ss");
            if (details.MatchLength.StartsWith("00:"))
            {
                details.MatchLength = details.MatchLength.Remove(0, 3);
                string Minutes = details.MatchLength.Substring(0, 2);
                string Seconds = details.MatchLength.Substring(3, 2);
                details.MatchLength = Minutes + "m " + Seconds + "s";
            }
            else
            {
                string Hours = details.MatchLength.Substring(0,2);
                string Minutes = details.MatchLength.Substring(3,2);
                string Seconds = details.MatchLength.Substring(6,2);
                details.MatchLength = Hours + "h " + Minutes + "m " + Seconds + "s";
            }
            #endregion

            #region Match start time
            details.MatchStartTime = DateTimeOffset.FromUnixTimeMilliseconds(Ret.matchInfo.gameStartMillis).UtcDateTime;
            #endregion

            #region Score
            int TeamID = 0;
            foreach (var Player in Ret.players)
            {
                if (Player.subject == au.Subject)
                {
                    if (Player.teamId == "Red")
                    {
                        TeamID = 0;
                        break;
                    }
                    else if (Player.teamId == "Blue")
                    {
                        TeamID = 1;
                        break;
                    }
                }
            }
            if (TeamID == 0)
            {
                details.Score = $"{Ret.teams[TeamID].roundsWon} - {Ret.teams[TeamID + 1].roundsWon}";
            }
            else if (TeamID == 1)
            {
                details.Score = $"{Ret.teams[TeamID].roundsWon} - {Ret.teams[TeamID - 1].roundsWon}";
            }
            #endregion

            #region KDA
            foreach (var Player in Ret.players)
            {
                if (Player.subject == au.Subject)
                {
                    details.KDA = $"{Player.stats.kills}/{Player.stats.deaths}/{Player.stats.assists}";
                }
            }
            #endregion

            #region KD
            decimal _KD = 0;
            foreach (var Player in Ret.players)
            {
                if (Player.subject == au.Subject)
                {
                    _KD = (decimal)Player.stats.kills / Player.stats.deaths;
                    details.KD = _KD.ToString("0.0");
                    //Kill = Player.stats.kills;
                }
            }
            #endregion

            #region HSs
            List<Damage> BigD = new List<Damage>();

            foreach (var round in Ret.roundResults)
            {
                foreach (var playerStat in round.playerStats)
                {
                    if (playerStat.subject == au.Subject)
                    {
                        //foreach (var kill in playerStat.kills)
                        //{
                            foreach (var damage in playerStat.damage)
                            {
                                //if (kill.victim == damage.receiver)
                                //{
                                    if ( (damage.headshots + damage.bodyshots + damage.legshots) != 0 )
                                    {
                                        BigD.Add(damage);
                                    }
                                //}
                            }
                        //}                       
                    }
                }
            }

            int TotalHits = 0;
            int _HSs = 0;

            foreach (var damage in BigD)
            {
                TotalHits += damage.headshots + damage.bodyshots + damage.legshots;
                _HSs += damage.headshots;
            }

            decimal _HS = (decimal)_HSs / TotalHits;
            _HS *= 100;
            _HS = Math.Round(_HS);
            details.HS = _HS + " %";
            #endregion

            #region ADR
            int roundsPlayed = 0;
            int totalDamage = 0;
            foreach (var Player in Ret.players)
            {
                if (au.Subject == Player.subject)
                {
                    roundsPlayed = Player.stats.roundsPlayed;
                    foreach (var Damage in Player.roundDamage)
                    {
                        totalDamage += Damage.damage;
                    }
                }
            }
            decimal _ADR = 0;
            _ADR = (decimal)totalDamage / roundsPlayed;
            string formattedADR = _ADR.ToString("0.0");
            if (formattedADR.EndsWith(".0"))
            {
                int i = formattedADR.IndexOf(".0");
                formattedADR = formattedADR.Remove(i, 2);
            }
            details.ADR = formattedADR;
            #endregion

            #region ACS
            float _AverageCombatScore = 0;
            foreach (var Player in Ret.players)
            {
                if (Player.subject == au.Subject)
                {
                    _AverageCombatScore = (float)Player.stats.score / Player.stats.roundsPlayed;
                    details.AverageCombatScore = Math.Round(_AverageCombatScore).ToString();
                }
            }
            #endregion

            #region First bloods
            int currentRound = 0;
            foreach (var kill in Ret.kills)
            {
                if (kill.round == currentRound)
                {
                    if (kill.killer == au.Subject)
                    {
                        details.FirstBloods++;
                    }
                    currentRound++;
                }
            }
            #endregion

            #region Plants & Defuses
            foreach (var result in Ret.roundResults)
            {
                if (result.plantSite != "")
                {
                    if (au.Subject == result.bombPlanter)
                    {
                        details.Plants++;
                    }
                    if (result.bombDefuser != null)
                    {
                        if (au.Subject == result.bombDefuser)
                        {
                            details.Defuses++;
                        }
                    }
                }
            }
            #endregion

            #region Econ rating
            details.EconRating = 0;
            #endregion

            #endregion

            var Players = Ret.players.OrderByDescending(x => x.stats.score).ToList<Player>();
            foreach (var Player in Players)
            {
                roundsPlayed = 0;
                totalDamage = 0;
                TotalHits = 0;
                _HSs = 0;
                matchOverview = new _MatchOverview();
                matchOverview.IDs = Player.subject;
                matchOverview.Agents = ConvertToAgent(Player.characterId);
                matchOverview.Names = Player.gameName + "#" + Player.tagLine;
                matchOverview.AverageCombatScores = (decimal)Player.stats.score / Player.stats.roundsPlayed;
                matchOverview.AverageCombatScores = Math.Round(matchOverview.AverageCombatScores);
                matchOverview.KDAs = Player.stats.kills + "/" + Player.stats.deaths + "/" + Player.stats.assists;
                matchOverview.KDs = (decimal)Player.stats.kills / Player.stats.deaths;
                matchOverview.KDs = Math.Round(matchOverview.KDs, 1);
                matchOverview.isPositive = Player.stats.kills - Player.stats.deaths;
                matchOverview.TotalRounds = Ret.teams[0].roundsPlayed >= Ret.teams[1].roundsPlayed ? Ret.teams[0].roundsPlayed : Ret.teams[1].roundsPlayed;

                roundsPlayed = Player.stats.roundsPlayed;
                foreach (var damage in Player.roundDamage)
                {
                    totalDamage += damage.damage;
                }
                _ADR = (decimal)totalDamage / roundsPlayed;
                matchOverview.ADRs = _ADR.ToString("0.0");
                if (matchOverview.ADRs.EndsWith(".0"))
                {
                    int i = matchOverview.ADRs.IndexOf(".0");
                    matchOverview.ADRs = matchOverview.ADRs.Remove(i, 2);
                }

                List<Damage> _BigD = new List<Damage>();

                foreach (var round in Ret.roundResults)
                {
                    foreach (var playerStat in round.playerStats)
                    {
                        if (playerStat.subject == Player.subject)
                        {
                            //foreach (var kill in playerStat.kills)
                            //{
                            foreach (var damage in playerStat.damage)
                            {
                                //if (kill.victim == damage.receiver)
                                //{
                                if ((damage.headshots + damage.bodyshots + damage.legshots) != 0)
                                {
                                    _BigD.Add(damage);
                                }
                                //}
                            }
                            //}

                        }
                    }
                }

                TotalHits = 0;
                _HSs = 0;

                foreach (var damage in _BigD)
                {
                    TotalHits += damage.headshots + damage.bodyshots + damage.legshots;
                    _HSs += damage.headshots;
                }

                _HS = (decimal)_HSs / TotalHits;
                _HS *= 100;
                _HS = Math.Round(_HS);
                matchOverview.HSs = _HS + " %";



                matchOverview.FirstBloods = 0;
                matchOverview.EconRatings = 0;
                matchOverview.Plants = 0;
                matchOverview.Defuses = 0;
                Ret.MatchOverview.Add(matchOverview);
            }

            currentRound = 0;
            foreach (var kill in Ret.kills)
            {
                if (kill.round == currentRound)
                {
                    foreach (var ov in Ret.MatchOverview)
                    {
                        if (ov.IDs == kill.killer)
                        {
                            ov.FirstBloods++;
                        }
                    }
                    currentRound++;
                }
            }

            foreach (var result in Ret.roundResults)
            {
                if (result.plantSite != "")
                {
                    foreach (var ov in Ret.MatchOverview)
                    {
                        if (ov.IDs == result.bombPlanter)
                        {
                            ov.Plants++;
                        }
                        if (result.bombDefuser != null)
                        {
                            if (ov.IDs == result.bombDefuser)
                            {
                                ov.Defuses++;
                            }
                        }
                    }
                }
            }

            Ret.Details.Add(details);
            Ret.StatusCode = (int)Response.StatusCode;
            return Ret;
        }

        public static string ConvertToAgent (string AgentID)
        {
            string Agent = "N/A";
            string[,] Agents = new string[,] { { "Breach", "5f8d3a7f-467b-97f3-062c-13acf203c006" }, { "Raze", "f94c3b30-42be-e959-889c-5aa313dba261" }, { "KAY/O", "601dbbe7-43ce-be57-2a40-4abd24953621" }, { "Skye", "6f2a04ca-43e0-be17-7f36-b3908627744d" }, { "Cypher", "117ed9e3-49f3-6512-3ccf-0cada7e3823b" }, { "Sova", "ded3520f-4264-bfed-162d-b080e2abccf9" }, { "Killjoy", "1e58de9c-4950-5125-93e9-a0aee9f98746" }, { "Viper", "707eab51-4836-f488-046a-cda6bf494859" }, { "Phoenix", "eb93336a-449b-9c1b-0a54-a891f7921d69" }, { "Astra", "41fb69c1-4189-7b37-f117-bcaf1e96f1bf" }, { "Brimstone", "9f0d8ba9-4140-b941-57d3-a7ad57c6b417" }, { "Yoru", "7f94d92c-4234-0a36-9646-3a87eb8b5c89" }, { "Sage", "569fdd95-4d10-43ab-ca70-79becc718b46" }, { "Reyna", "a3bfb853-43b2-7238-a4f1-ad90e9e46bcc" }, { "Omen", "8e253930-4c05-31dd-1b6c-968525494517" }, { "Jett", "add6443a-41bd-e414-f6ad-e58d267f4e95" }, { "Chamber", "22697a3d-45bf-8dd7-4fec-84a9e28c69d7" }, { "Neon", "bb2a4828-46eb-8cd1-e765-15848195d751" }, { "Fade", "dade69b4-4f5a-8528-247b-219e5a1facd6" } };
            for (int i = 0; i < 19; i++)
            {
                if (string.Equals(Agents[i, 1], AgentID, StringComparison.CurrentCultureIgnoreCase))
                {
                    Agent = Agents[i, 0];
                }
            }
            return Agent;
        }

    }
}
