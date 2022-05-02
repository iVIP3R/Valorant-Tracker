using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Valorant_Tracker
{
    class RiotClient
    {
        public string ClientVersion { get; set; }
        public int StatusCode;

        public static RiotClient GetClientVersion()
        {
            RiotClient Ret = new RiotClient();
            RestClient Client = new RestClient(new Uri("https://valorant-api.com/v1/version"));
            RestRequest Request = new RestRequest(Method.GET);
            var Response = Client.Execute(Request);
            string ResponseContent = Response.Content;
            var riotClientVersion = JsonConvert.DeserializeObject(ResponseContent);
            JToken riotClientVersionObj = JObject.FromObject(riotClientVersion);
            Ret.ClientVersion = riotClientVersionObj["data"]["riotClientVersion"].Value<string>();
            Ret.StatusCode = (int)Response.StatusCode;
            return Ret;
        }
    }
}
