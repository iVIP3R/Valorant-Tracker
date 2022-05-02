using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RestSharp;

namespace Valorant_Tracker
{
    class Content
    {
        public List<Character> Characters { get; set; }
        public List<Map> Maps { get; set; }
        public List<Chroma> Chromas { get; set; }
        public List<Skin> Skins { get; set; }
        public List<SkinLevel> SkinLevels { get; set; }
        public List<Attachment> Attachments { get; set; }
        public List<Equip> Equips { get; set; }
        public List<Theme> Themes { get; set; }
        public List<GameMode> GameModes { get; set; }
        public List<Spray> Sprays { get; set; }
        public List<SprayLevel> SprayLevels { get; set; }
        public List<Charm> Charms { get; set; }
        public List<CharmLevel> CharmLevels { get; set; }
        public List<PlayerCard> PlayerCards { get; set; }
        public List<PlayerTitle> PlayerTitles { get; set; }
        public List<StorefrontItem> StorefrontItems { get; set; }
        public List<Season> Seasons { get; set; }
        public List<CompetitiveSeason> CompetitiveSeasons { get; set; }
        public List<Event> Events { get; set; }
        public int StatusCode { get; set; }

        public class Character
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public string AssetName { get; set; }
            public bool IsEnabled { get; set; }
        }

        public class Map
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public string AssetName { get; set; }
            public bool IsEnabled { get; set; }
        }

        public class Chroma
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public string AssetName { get; set; }
            public bool IsEnabled { get; set; }
        }

        public class Skin
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public string AssetName { get; set; }
            public bool IsEnabled { get; set; }
        }

        public class SkinLevel
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public string AssetName { get; set; }
            public bool IsEnabled { get; set; }
        }

        public class Attachment
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public string AssetName { get; set; }
            public bool IsEnabled { get; set; }
        }

        public class Equip
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public string AssetName { get; set; }
            public bool IsEnabled { get; set; }
        }

        public class Theme
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public string AssetName { get; set; }
            public bool IsEnabled { get; set; }
        }

        public class GameMode
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public string AssetName { get; set; }
            public bool IsEnabled { get; set; }
        }

        public class Spray
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public string AssetName { get; set; }
            public bool IsEnabled { get; set; }
        }

        public class SprayLevel
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public string AssetName { get; set; }
            public bool IsEnabled { get; set; }
        }

        public class Charm
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public string AssetName { get; set; }
            public bool IsEnabled { get; set; }
        }

        public class CharmLevel
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public string AssetName { get; set; }
            public bool IsEnabled { get; set; }
        }

        public class PlayerCard
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public string AssetName { get; set; }
            public bool IsEnabled { get; set; }
        }

        public class PlayerTitle
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public string AssetName { get; set; }
            public bool IsEnabled { get; set; }
        }

        public class StorefrontItem
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public string AssetName { get; set; }
            public bool IsEnabled { get; set; }
        }

        public class Season
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public bool IsEnabled { get; set; }
            public bool IsActive { get; set; }
            public bool DevelopmentOnly { get; set; }
        }

        public class CompetitiveSeason
        {
            public string ID { get; set; }
            public string SeasonID { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public bool DevelopmentOnly { get; set; }
        }

        public class Event
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public bool IsEnabled { get; set; }
            public bool IsActive { get; set; }
            public bool DevelopmentOnly { get; set; }
        }

        public static Content Get(Auth au)
        {
            Content Ret = new Content();
            string URL = "https://shared." + au.Region + ".a.pvp.net/content-service/v2/content";
            RestClient client = new RestClient(URL);
            client.CookieContainer = au.cookies;
            //client.CookieContainer = new CookieContainer();

            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {au.AccessToken}");
            request.AddHeader("X-Riot-ClientPlatform", $"{Info.ClientPlatform}");
            request.AddHeader("X-Riot-ClientVersion", $"{au.ClientVersion}");

            var Response = client.Execute(request);
            string ResponseContent = Response.Content;
            Ret = JsonConvert.DeserializeObject<Content>(ResponseContent);
            Ret.StatusCode = (int)Response.StatusCode;
            return Ret;
        }
    }
}
