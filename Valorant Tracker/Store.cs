using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using System.Windows.Forms;
using System.Linq;

namespace Valorant_Tracker
{
    class Store
    {
        public _FeaturedBundle FeaturedBundle { get; set; }
        public _SkinsPanelLayout SkinsPanelLayout { get; set; }
        public _BonusStore BonusStore { get; set; }
        public string[,] FormattedSkinsPanelLayout = new string[4, 2];
        public _CurrentBundle CurrentBundle { get; set; }
        public int StatusCode;

        public class _CurrentBundle
        {
            public List<string> Names { get; set; }
            public List<int> Prices { get; set; }
            public List<string> Images { get; set; }

        }

        public class Item2
        {
            public string ItemTypeID { get; set; }
            public string ItemID { get; set; }
            public int Amount { get; set; }
        }

        public class _Item
        {
            public _Item Item { get; set; }
            public int BasePrice { get; set; }
            public string CurrencyID { get; set; }
            public float DiscountPercent { get; set; }
            public int DiscountedPrice { get; set; }
            public bool IsPromoItem { get; set; }
        }

        public class Bundle
        {
            public string ID { get; set; }
            public string DataAssetID { get; set; }
            public string CurrencyID { get; set; }
            public List<_Item> Items { get; set; }
        }

        public class _FeaturedBundle
        {
            public Bundle Bundle { get; set; }
            public int BundleRemainingDurationInSeconds { get; set; }
            public string FormattedBundleRemainingDuration { get; set; }
        }

        public class _SkinsPanelLayout
        {
            public List<string> SingleItemOffers { get; set; }
            public int SingleItemOffersRemainingDurationInSeconds { get; set; }
            public string FormattedSingleItemOffersRemainingDuration { get; set; }
        }

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
            public string StartDate { get; set; }
            public Cost Cost { get; set; }
            public List<Reward> Rewards { get; set; }
        }

        public class DiscountCosts
        {
            [JsonProperty("85ad13f7-3d1b-5128-9eb2-7cd8ee0b5741")]
            public int _85ad13f73d1b51289eb27cd8ee0b5741 { get; set; }
        }

        public class BonusStoreOffer
        {
            public string BonusOfferID { get; set; }
            public Offer Offer { get; set; }
            public int DiscountPercent { get; set; }
            public DiscountCosts DiscountCosts { get; set; }
            public bool IsSeen { get; set; }
        }

        public class _BonusStore
        {
            public List<BonusStoreOffer> BonusStoreOffers { get; set; }
            public int BonusStoreRemainingDurationInSeconds { get; set; }
            public string FormattedBonusStoreRemainingDuration { get; set; }
        }

        public static Store GetOffers(Auth au)
        {
            Store Ret = new Store();
            string URL = "https://pd." + au.Region + ".a.pvp.net/store/v2/storefront/" + au.Subject;
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
            Ret = JsonConvert.DeserializeObject<Store>(ResponseContent);
            Ret.FormattedSkinsPanelLayout = FormatOffers(au, Ret.SkinsPanelLayout.SingleItemOffers);
            Ret.SkinsPanelLayout.FormattedSingleItemOffersRemainingDuration = TimeSpan.FromSeconds(Ret.SkinsPanelLayout.SingleItemOffersRemainingDurationInSeconds).ToString(@"hh\:mm\:ss");
            Ret.FeaturedBundle.FormattedBundleRemainingDuration = TimeSpan.FromSeconds(Ret.FeaturedBundle.BundleRemainingDurationInSeconds).ToString(@"hh\:mm\:ss");
            if (!(Ret.BonusStore == null))
            {
                Ret.BonusStore.FormattedBonusStoreRemainingDuration = TimeSpan.FromSeconds(Ret.BonusStore.BonusStoreRemainingDurationInSeconds).ToString(@"hh\:mm\:ss");
            }
            Ret.StatusCode = (int)Response.StatusCode;
            return Ret;
        }

        private static string[,] FormatOffers(Auth au, List<string> IDs)
        {
            string[,] FormattedOffers = new string[4, 2];
            for (int i = 0; i < 4; i++)
            {
                _Content c = _Content.Search(au, IDs[i]);
                FormattedOffers[i, 0] = c.data.displayName;
                FormattedOffers[i, 1] = c.data.displayIcon;
            }
            return FormattedOffers;
        }
    }
}
