using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Valorant_Tracker
{
    class Party
    {
        public string Subject { get; set; }
        public long Version { get; set; }
        public string CurrentPartyID { get; set; }
        public object Invites { get; set; }
        public List<object> Requests { get; set; }
        public _PlatformInfo PlatformInfo { get; set; }
        public int StatusCode;

        public class _PlatformInfo
        {
            public string platformType { get; set; }
            public string platformOS { get; set; }
            public string platformOSVersion { get; set; }
            public string platformChipset { get; set; }
        }

        public static Party Get(Auth au)
        {
            Party Ret = new Party();
            string URL = "https://glz-" + au.Region + "-1." + au.Region + ".a.pvp.net/parties/v1/players/" + au.Subject;
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
            Ret = JsonConvert.DeserializeObject<Party>(ResponseContent);
            Ret.StatusCode = (int)Response.StatusCode;
            return Ret;
        }
    }
}
