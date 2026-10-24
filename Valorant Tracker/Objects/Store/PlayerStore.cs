using Newtonsoft.Json;
using System.Collections.Generic;

namespace Valorant_Tracker.Objects.Store
{
    public class PlayerStore
    {
        public FeaturedBundle FeaturedBundle { get; set; }
        public SkinsPanelLayout DailyOffers { get; set; }
        public BonusStore BonusStore { get; set; }  
    }

    public class FeaturedBundle
    {
        public Bundle Bundle { get; set; }
        public List<Bundle> Bundles { get; set; }
        public int BundleRemainingDurationInSeconds { get; set; }
    }

    public class Bundle
    {
        public string ID { get; set; }
        public string DataAssetID { get; set; }
        public string CurrencyID { get; set; }
        public List<Item> Items { get; set; }
        public int DurationRemainingInSeconds { get; set; }
        public bool WholesaleOnly { get; set; }
    }

    public class Item
    {
        [JsonProperty("Item")]
        public ItemOffer ItemData { get; set; }
        public int BasePrice { get; set; }
        public string CurrencyID { get; set; }
        public int DiscountPercent { get; set; }
        public int DiscountedPrice { get; set; }
        public bool IsPromoItem { get; set; }
    }

    public class ItemOffer
    {
        public string ItemTypeID { get; set; }
        public string ItemID { get; set; }
        public int Amount { get; set; }
    }

    public class SkinsPanelLayout
    {
        public List<string> SingleItemOffers { get; set; }
        public int SingleItemOffersRemainingDurationInSeconds { get; set; }
    }

    public class BonusStore
    {
        public List<BonusStoreOffer> BonusStoreOffers { get; set; }
        public int BonusStoreRemainingDurationInSeconds { get; set; }
    }

    public class BonusStoreOffer
    {
        public string BonusOfferID { get; set; }
        public Offer Offer { get; set; }
        public int DiscountPercent { get; set; }
        public Cost DiscountCosts { get; set; }
        public bool IsSeen { get; set; }
    }

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
}