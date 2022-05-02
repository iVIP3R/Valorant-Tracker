using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Valorant_Tracker
{
    public class Balances
    {
        public int ValorantPoints { get; set; }
        public int RadianitePoints { get; set; }
        public int FreeAgents { get; set; }
        public int StatusCode;

        public static Balances GetBalance(Auth au)
        {
            Balances ret = new Balances();
            RestClient client = new RestClient($"https://pd.eu.a.pvp.net/store/v1/wallet/{au.Subject}");
            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {au.AccessToken}");
            request.AddHeader("X-Riot-Entitlements-JWT", $"{au.EntitlementToken}");
            var Response = client.Execute(request);
            string ResponseContent = Response.Content;
            JObject obj = JObject.FromObject(JsonConvert.DeserializeObject(ResponseContent));
            ret.ValorantPoints = obj["Balances"].Value<int>("85ad13f7-3d1b-5128-9eb2-7cd8ee0b5741");
            ret.RadianitePoints = obj["Balances"].Value<int>("e59aa87c-4cbf-517a-5983-6e81511be9b7");
            ret.FreeAgents = obj["Balances"].Value<int>("f08d4ae3-939c-4576-ab26-09ce1f23bb37");
            ret.StatusCode = (int)Response.StatusCode;
            return ret;
        }
    }
}