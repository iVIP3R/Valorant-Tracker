namespace Valorant_Tracker
{
    public enum region
    {
        EU,
        NA,
        AP,
        KO
    }

    public readonly struct Info
    {
        public static string ClientPlatform = "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9";
    }

    public readonly struct Seasons
    {
        public static string ClosedBeta = "0df5adb9-4dcb-6899-1306-3e9860661dd3";

        public static string Episode1_Act1 = "3f61c772-4560-cd3f-5d3f-a7ab5abda6b3";
        public static string Episode1_Act2 = "0530b9c4-4980-f2ee-df5d-09864cd00542";
        public static string Episode1_Act3 = "46ea6166-4573-1128-9cea-60a15640059b";

        public static string Episode2_Act1 = "97b6e739-44cc-ffa7-49ad-398ba502ceb0";
        public static string Episode2_Act2 = "ab57ef51-4e59-da91-cc8d-51a5a2b9b8ff";
        public static string Episode2_Act3 = "52e9749a-429b-7060-99fe-4595426a0cf7";

        public static string Episode3_Act1 = "2a27e5d2-4d30-c9e2-b15a-93b8909a442c";
        public static string Episode3_Act2 = "4cb622e1-4244-6da3-7276-8daaf1c01be2";
        public static string Episode3_Act3 = "a16955a5-4ad0-f761-5e9e-389df1c892fb";

        public static string Episode4_Act1 = "573f53ac-41a5-3a7d-d9ce-d6a6298e5704";
        public static string Episode4_Act2 = "d929bc38-4ab6-7da4-94f0-ee84f8ac141e";
        public static string Episode4_Act3 = "3e47230a-463c-a301-eb7d-67bb60357d4f";

        public static string Episode5_Act1 = "67e373c7-48f7-b422-641b-079ace30b427";
        public static string Episode5_Act2 = "7a85de9a-4032-61a9-61d8-f4aa2b4a84b6";
        public static string Episode5_Act3 = "aca29595-40e4-01f5-3f35-b1b3d304c96e";


        public static string Episode26_Act5 = "3737c391-497a-6e82-aeb5-cc9f701f72e2";
    }

    public readonly struct GameMode
    {
        public static string Unrated = "unrated";
        public static string Competitive = "competitive";
        public static string Spike_Rush = "spikerush";
        public static string Deathmatch = "deathmatch";
        public static string Escalation = "ggteam";
        public static string Replication = "onefa";
        public static string Snowball_Fight = "snowball";
        public static string Custom = "custom";
    }

    public readonly struct Agent
    {
        public static string Breach = "5f8d3a7f-467b-97f3-062c-13acf203c006";
        public static string Raze = "f94c3b30-42be-e959-889c-5aa313dba261";
        public static string KAYO = "601DBBE7-43CE-BE57-2A40-4ABD24953621";
        public static string Skye = "6f2a04ca-43e0-be17-7f36-b3908627744d";
        public static string Cypher = "117ed9e3-49f3-6512-3ccf-0cada7e3823b";
        public static string Sova = "ded3520f-4264-bfed-162d-b080e2abccf9";
        public static string Killjoy = "1e58de9c-4950-5125-93e9-a0aee9f98746";
        public static string Viper = "707eab51-4836-f488-046a-cda6bf494859";
        public static string Phoenix = "eb93336a-449b-9c1b-0a54-a891f7921d69";
        public static string Astra = "41fb69c1-4189-7b37-f117-bcaf1e96f1bf";
        public static string Brimstone = "9f0d8ba9-4140-b941-57d3-a7ad57c6b417";
        public static string Yoru = "7f94d92c-4234-0a36-9646-3a87eb8b5c89";
        public static string Sage = "569fdd95-4d10-43ab-ca70-79becc718b46";
        public static string Reyna = "a3bfb853-43b2-7238-a4f1-ad90e9e46bcc";
        public static string Omen = "8e253930-4c05-31dd-1b6c-968525494517";
        public static string Jett = "add6443a-41bd-e414-f6ad-e58d267f4e95";
        public static string Neon = "bb2a4828-46eb-8cd1-e765-15848195d751";
        public static string Chamber = "22697a3d-45bf-8dd7-4fec-84a9e28c69d7";
        public static string Fade = "dade69b4-4f5a-8528-247b-219e5a1facd6";
    }

    public readonly struct Map
    {
        public static string Ascent = "/Game/Maps/Ascent/Ascent";
        public static string Split = "/Game/Maps/Bonsai/Bonsai";
        public static string Fracture = "/Game/Maps/Canyon/Canyon";
        public static string Bind = "/Game/Maps/Duality/Duality";
        public static string Breeze = "/Game/Maps/Foxtrot/Foxtrot";
        public static string Pearl = "/Game/Maps/Pitt/Pitt";
        public static string Icebox = "/Game/Maps/Port/Port";
        public static string Haven = "/Game/Maps/Triad/Triad";
    }
}
