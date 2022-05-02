using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Valorant_Tracker
{
    class _Content
    {
        public int status { get; set; }
        public Data data { get; set; }
        public class Data
        {
            public string uuid { get; set; }
            public string displayName { get; set; }
            public object levelItem { get; set; }
            public string displayIcon { get; set; }
            public string streamedVideo { get; set; }
            public string assetPath { get; set; }
        }

        public static _Content Search(Auth au, string ID)
        {
            _Content ret = new _Content();
            RestClient client = new RestClient($"https://valorant-api.com/v1/weapons/skinlevels/{ID}");
            RestRequest request = new RestRequest(Method.GET);
            var Response = client.Execute(request);
            string ResponseContent = Response.Content;
            ret = JsonConvert.DeserializeObject<_Content>(ResponseContent);
            ret.status = (int)Response.StatusCode;
            return ret;
        }

    }
}
