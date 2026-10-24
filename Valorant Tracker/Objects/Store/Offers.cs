using Newtonsoft.Json;
using System.Collections.Generic;

namespace Valorant_Tracker.Objects.Store
{
    public class Offers
    {
        [JsonProperty("Offers")]
        public List<Offer> Items { get; set; }
        public List<UpgradeCurrencyOffer> UpgradeCurrencyOffers { get; set; }

        public class Offer
        {
            public string OfferID { get; set; }
            public bool IsDirectPurchase { get; set; }
            public string StartDate { get; set; }
            public Cost Cost { get; set; }
            public List<Reward> Rewards { get; set; }
        }

        public class Cost
        {
            [JsonProperty("85ad13f7-3d1b-5128-9eb2-7cd8ee0b5741")]
            public int VP { get; set; }
        }

        public class Reward
        {
            public string ItemTypeID { get; set; }
            public string ItemID { get; set; }
            public int Quantity { get; set; }
        }

        public class UpgradeCurrencyOffer
        {
            public string OfferID { get; set; }
            public string StorefrontItemID { get; set; }
        }
    }
}
