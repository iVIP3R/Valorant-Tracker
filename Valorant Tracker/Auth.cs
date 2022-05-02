﻿using Microsoft.IdentityModel.JsonWebTokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Net;
using System.Text.RegularExpressions;

namespace Valorant_Tracker
{
    public class Auth
    {
        public string EntitlementToken { get; set; }
        public string AccessToken { get; set; }
        public string Subject { get; set; }
        public CookieContainer cookies { get; set; }
        public string ClientVersion;
        public region Region;
        public static Auth Login(string Username, string Password, region reg)
        {
            Auth au = new Auth();
            au.Region = reg;
            string EntitlementToken;
            string AccessToken;
            au.cookies = new CookieContainer();
            string url = "https://auth.riotgames.com/api/v1/authorization";
            RestClient client = new RestClient(url);

            client.CookieContainer = au.cookies;

            RestRequest request = new RestRequest(Method.POST);
            string body = "{\"client_id\":\"play-valorant-web-prod\",\"nonce\":\"1\",\"redirect_uri\":\"https://playvalorant.com/opt_in" + "\",\"response_type\":\"token id_token\",\"scope\":\"account openid\"}";
            request.AddJsonBody(body);
            client.Execute(request);
            RestClient authclient = new RestClient("https://auth.riotgames.com/api/v1/authorization");

            authclient.CookieContainer = au.cookies;

            RestRequest authrequest = new RestRequest(Method.PUT);
            string authbody = "{\"type\":\"auth\",\"username\":\"" + Username + "\",\"password\":\"" + Password + "\"}";
            authrequest.AddJsonBody(authbody);
            string authresult = authclient.Execute(authrequest).Content;
            var authJson = JsonConvert.DeserializeObject(authresult);
            JToken authObj = JObject.FromObject(authJson);
            if (authresult.Contains("auth_failure"))
            {
                return new Auth();
            }
            string authURL = authObj["response"]["parameters"]["uri"].Value<string>();
            var access_tokenVar = Regex.Match(authURL, @"access_token=(.+?)&scope=").Groups[1].Value;
            AccessToken = $"{access_tokenVar}";

            RestClient entitlementclient = new RestClient(new Uri("https://entitlements.auth.riotgames.com/api/token/v1"));
            RestRequest entitlementrequest = new RestRequest(Method.POST);

            entitlementrequest.AddHeader("Authorization", $"Bearer {AccessToken}");
            entitlementrequest.AddJsonBody("{}");
            entitlementclient.CookieContainer = au.cookies;
            string response = entitlementclient.Execute(entitlementrequest).Content;
            var entitlement_token = JsonConvert.DeserializeObject(response);
            JToken entitlement_tokenObj = JObject.FromObject(entitlement_token);

            EntitlementToken = entitlement_tokenObj["entitlements_token"].Value<string>();
            au.AccessToken = AccessToken;
            au.EntitlementToken = EntitlementToken;
            var jsonWebToken = new JsonWebToken(AccessToken);
            au.Subject = jsonWebToken.Subject;

            RestClient versionclient = new RestClient("https://valorant-api.com/v1/version");
            RestRequest versionrequest = new RestRequest(Method.GET);
            string json = versionclient.Execute(versionrequest).Content;
            var version = JsonConvert.DeserializeObject(json);
            JToken versionobj = JObject.FromObject(version);

            string versionformat = versionobj["data"]["riotClientVersion"].Value<string>();
            au.ClientVersion = versionformat;
            return au;
        }
    }

}