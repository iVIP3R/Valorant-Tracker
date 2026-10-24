using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Valorant_Tracker.Services;
using Valorant_Tracker.Utils;

namespace Valorant_Tracker.Data
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
            public string Team;
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

        public class NameServicePlayer
        {
            public string DisplayName { get; set; }
            public string Subject { get; set; }
            public string GameName { get; set; }
            public string TagLine { get; set; }
        }

        public static MatchDetails Get(Auth au, string MatchID)
        {
            MatchDetails Ret = new MatchDetails();

            string URL = $"https://pd.{au.RegionShard}.a.pvp.net/match-details/v1/matches/{MatchID}";
            RestClient client = new RestClient(URL);
            client.CookieContainer = au.cookies;

            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {au.AccessToken}");
            request.AddHeader("X-Riot-Entitlements-JWT", $"{au.EntitlementToken}");

            request.AddHeader("X-Riot-ClientPlatform", Info.ClientPlatform);
            request.AddHeader("X-Riot-ClientVersion", au.ClientVersion);

            var Response = client.Execute(request);
            string ResponseContent = Response.Content;
            Ret = JsonConvert.DeserializeObject<MatchDetails>(ResponseContent);

            if (Ret == null || Ret.matchInfo == null || Ret.players == null)
            {
                throw new InvalidOperationException($"Failed to load match details (HTTP {(int)Response.StatusCode}). The match may be too old, or the API rejected the request.");
            }

            Ret.Details = new List<_Details>();
            Ret.MatchOverview = new List<_MatchOverview>();
            _Details details = new _Details();
            _MatchOverview matchOverview = new _MatchOverview();

            #region Details

            #region Map
            var mapData = ValorantDataService.FindMapAsync(Ret.matchInfo.mapId).GetAwaiter().GetResult();
            details.Map = mapData?.DisplayName ?? Ret.matchInfo.mapId;
            #endregion

            #region Server
            details.Server = GetServerName(Ret.matchInfo.gamePodId);
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

            string userTeam = Ret.players.FirstOrDefault(p => p.subject == au.Subject)?.teamId ?? "Blue";

            var puuids = Ret.players.Select(p => p.subject).Where(s => !string.IsNullOrEmpty(s)).ToList();
            var realNames = GetPlayerNames(au, puuids);

            var Players = Ret.players
                .OrderBy(x => x.teamId == userTeam ? 0 : 1)
                .ThenByDescending(x => x.stats.score)
                .ToList<Player>();

            foreach (var Player in Players)
            {
                roundsPlayed = 0;
                totalDamage = 0;
                TotalHits = 0;
                _HSs = 0;
                matchOverview = new _MatchOverview();
                matchOverview.Team = Player.teamId;
                matchOverview.IDs = Player.subject;
                matchOverview.Agents = ConvertToAgent(Player.characterId);
                string pName = Player.gameName;
                string pTag = Player.tagLine;

                if (realNames.TryGetValue(Player.subject, out var ns) && !string.IsNullOrWhiteSpace(ns.gameName))
                {
                    matchOverview.Names = $"{ns.gameName}#{ns.tagLine}";
                }
                else if (Player.subject == au.Subject)
                {
                    matchOverview.Names = "You";
                }
                else
                {
                    matchOverview.Names = $"Player ({Player.subject.Substring(0, 8)})";
                }
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

        public static string ConvertToAgent(string AgentID)
        {
            if (string.IsNullOrEmpty(AgentID)) return "N/A";

            var agent = ValorantDataService.FindAgentAsync(AgentID).GetAwaiter().GetResult();
            return agent?.DisplayName ?? "N/A";
        }

        private static string GetServerName(string gamePodId)
        {
            if (string.IsNullOrEmpty(gamePodId)) return "N/A";
            var match = Regex.Match(gamePodId, @"-gp-([a-zA-Z]+)(?:-|$)");
            if (match.Success)
            {
                string city = match.Groups[1].Value;
                return char.ToUpper(city[0]) + city.Substring(1);
            }

            return gamePodId;
        }

        public static Dictionary<string, (string gameName, string tagLine)> GetPlayerNames(Auth au, List<string> puuids)
        {
            var names = new Dictionary<string, (string, string)>();
            if (puuids == null || puuids.Count == 0) return names;

            string url = $"https://pd.{au.RegionShard}.a.pvp.net/name-service/v2/players";
            var client = new RestClient(url);
            client.CookieContainer = au.cookies;

            var request = new RestRequest(Method.PUT);
            request.AddHeader("Authorization", $"Bearer {au.AccessToken}");
            request.AddHeader("X-Riot-Entitlements-JWT", au.EntitlementToken);
            request.AddHeader("X-Riot-ClientPlatform", Info.ClientPlatform);
            request.AddHeader("X-Riot-ClientVersion", au.ClientVersion);

            request.AddJsonBody(puuids);

            var response = client.Execute(request);

            if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
            {
                var result = JsonConvert.DeserializeObject<List<NameServicePlayer>>(response.Content);
                if (result != null)
                {
                    foreach (var p in result)
                    {
                        if (!string.IsNullOrEmpty(p.Subject) && !string.IsNullOrEmpty(p.GameName))
                        {
                            names[p.Subject] = (p.GameName, p.TagLine);
                        }
                    }
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"[NameService] v2 failed: {(int)response.StatusCode} - {response.Content}");
            }

            return names;
        }

    }
}
