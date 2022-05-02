using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Valorant_Tracker
{
    class PregamePlayer
    {
        public string Subject { get; set; }
        public string MatchID { get; set; }
        public long Version { get; set; }
        public int StatusCode;

        public static PregamePlayer GetCurrentMatch(Auth au)
        {
            PregamePlayer Ret = new PregamePlayer();
            string URL = "https://glz-" + au.Region + "-1." + au.Region + ".a.pvp.net/pregame/v1/players/" + au.Subject;
            RestClient client = new RestClient(URL);
            client.CookieContainer = au.cookies;
            //client.CookieContainer = new CookieContainer();

            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {au.AccessToken}");
            request.AddHeader("X-Riot-Entitlements-JWT", $"{au.EntitlementToken}");

            var Response = client.Execute(request);
            string ResponseContent = Response.Content;
            Ret = JsonConvert.DeserializeObject<PregamePlayer>(ResponseContent);
            Ret.StatusCode = (int)Response.StatusCode;
            return Ret;
        }
    }
}
