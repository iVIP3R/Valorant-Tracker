using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using System.Windows.Forms;
using System.Linq;

namespace Valorant_Tracker
{
    class OfferIDs
    {

        public List<Offer> Offers { get; set; }
        public List<UpgradeCurrencyOffer> UpgradeCurrencyOffers { get; set; }
        public int StatusCode;

        public class Cost
        {
            [JsonProperty("85ad13f7-3d1b-5128-9eb2-7cd8ee0b5741")]
            public int _85ad13f73d1b51289eb27cd8ee0b5741 { get; set; }
        }

        public class Reward
        {
            public string ItemTypeID { get; set; }
            public string ItemID { get; set; }
            public int Quantity { get; set; }
        }

        public class Offer
        {
            public string OfferID { get; set; }
            public bool IsDirectPurchase { get; set; }
            public object StartDate { get; set; }
            public Cost Cost { get; set; }
            public List<Reward> Rewards { get; set; }
        }

        public class UpgradeCurrencyOffer
        {
            public string OfferID { get; set; }
            public string StorefrontItemID { get; set; }
        }

        public static OfferIDs Get(Auth au)
        {
            OfferIDs Ret = new OfferIDs();
            string URL = "https://pd." + au.Region + ".a.pvp.net/store/v1/offers/";
            RestClient client = new RestClient(URL);
            client.CookieContainer = au.cookies;
            //client.CookieContainer = new CookieContainer();

            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {au.AccessToken}");
            request.AddHeader("X-Riot-Entitlements-JWT", $"{au.EntitlementToken}");

            var Response = client.Execute(request);
            string ResponseContent = Response.Content;
            Ret = JsonConvert.DeserializeObject<OfferIDs>(ResponseContent);
            Ret.StatusCode = (int)Response.StatusCode;
            return Ret;
        }

    }
}
