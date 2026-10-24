using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;

namespace Valorant_Tracker
{
    class Store
    {
        public _FeaturedBundle FeaturedBundle { get; set; }
        public _SkinsPanelLayout SkinsPanelLayout { get; set; }

        public _UpgradeCurrencyStore UpgradeCurrencyStore { get; set; }
        public _AccessoryStore AccessoryStore { get; set; }

        public List<PluginStore> PluginStores { get; set; }

        public string[,] FormattedSkinsPanelLayout = new string[4, 2];

        public int StatusCode;


        // =========================
        // Featured Bundle
        // =========================

        public class _FeaturedBundle
        {
            public Bundle Bundle { get; set; }
            public List<Bundle> Bundles { get; set; }
            public List<FeaturedTileEntry> FeaturedTileEntries { get; set; }

            public int BundleRemainingDurationInSeconds { get; set; }
            public string FormattedBundleRemainingDuration { get; set; }
        }

        public class Bundle
        {
            public string ID { get; set; }
            public string DataAssetID { get; set; }
            public string CurrencyID { get; set; }

            public List<BundleItem> Items { get; set; }
            public List<BundleItemOffer> ItemOffers { get; set; }

            public Dictionary<string, int> TotalBaseCost { get; set; }
            public Dictionary<string, int> TotalDiscountedCost { get; set; }
            public float TotalDiscountPercent { get; set; }

            public int DurationRemainingInSeconds { get; set; }
            public bool WholesaleOnly { get; set; }
            public int IsGiftable { get; set; }
        }

        public class BundleItem
        {
            public Item Item { get; set; }

            public int BasePrice { get; set; }
            public string CurrencyID { get; set; }
            public float DiscountPercent { get; set; }
            public int DiscountedPrice { get; set; }
            public bool IsPromoItem { get; set; }
        }

        public class BundleItemOffer
        {
            public string BundleItemOfferID { get; set; }
            public Offer Offer { get; set; }

            public float DiscountPercent { get; set; }
            public Dictionary<string, int> DiscountedCost { get; set; }
        }

        public class FeaturedTileEntry
        {
            public string Offer { get; set; }
            public string OfferType { get; set; }
            public string Tile { get; set; }
            public string Text { get; set; }
            public FeaturedTileEntryData Data { get; set; }
        }

        public class FeaturedTileEntryData
        {
            public string ID { get; set; }
            public string Image { get; set; }
        }


        // =========================
        // Items / Offers
        // =========================

        public class Item
        {
            public string ItemTypeID { get; set; }
            public string ItemID { get; set; }
            public int Amount { get; set; }
        }

        public class Offer
        {
            public string OfferID { get; set; }
            public bool IsDirectPurchase { get; set; }
            public DateTime StartDate { get; set; }

            public Dictionary<string, int> Cost { get; set; }

            public List<Reward> Rewards { get; set; }
        }

        public class Reward
        {
            public string ItemTypeID { get; set; }
            public string ItemID { get; set; }
            public int Quantity { get; set; }
        }


        // =========================
        // Daily Store
        // =========================

        public class _SkinsPanelLayout
        {
            public List<string> SingleItemOffers { get; set; }

            public List<Offer> SingleItemStoreOffers { get; set; }

            public int SingleItemOffersRemainingDurationInSeconds { get; set; }

            public string FormattedSingleItemOffersRemainingDuration { get; set; }
        }


        // =========================
        // Upgrade Currency Store
        // =========================

        public class _UpgradeCurrencyStore
        {
            public List<UpgradeCurrencyOffer> UpgradeCurrencyOffers { get; set; }
        }

        public class UpgradeCurrencyOffer
        {
            public string OfferID { get; set; }
            public string StorefrontItemID { get; set; }

            public Offer Offer { get; set; }

            public float DiscountedPercent { get; set; }
        }


        // =========================
        // Accessory Store
        // =========================

        public class _AccessoryStore
        {
            public List<AccessoryStoreOffer> AccessoryStoreOffers { get; set; }

            public int AccessoryStoreRemainingDurationInSeconds { get; set; }

            public string StorefrontID { get; set; }
        }

        public class AccessoryStoreOffer
        {
            public Offer Offer { get; set; }

            public string ContractID { get; set; }
        }


        // =========================
        // Plugin Stores
        // =========================

        public class PluginStore
        {
            public string PluginID { get; set; }
            public PluginOffers PluginOffers { get; set; }
        }

        public class PluginOffers
        {
            public List<PluginStoreOffer> StoreOffers { get; set; }
        }

        public class PluginStoreOffer
        {
            public string OfferID { get; set; }
            public string StorefrontItemID { get; set; }

            public PluginPurchaseInformation PurchaseInformation { get; set; }

            public List<PluginSubOffer> SubOffers { get; set; }
        }

        public class PluginPurchaseInformation
        {
            public Offer Offer { get; set; }
        }

        public class PluginSubOffer
        {
            public string OfferID { get; set; }
            public Dictionary<string, int> Cost { get; set; }
        }


        // =========================
        // API
        // =========================

        public static Store GetOffers(Auth au)
        {
            if (au == null)
                throw new ArgumentNullException(nameof(au));

            using var client = new ValorantApiClient(au.ToRiotSession());

            var emptyJsonContent = new StringContent("{}", Encoding.UTF8, "application/json");

            var ret = client
                .PostPlayerDataAsync<Store>(
                    $"store/v3/storefront/{au.Subject}",
                    emptyJsonContent
                )
                .GetAwaiter()
                .GetResult();

            if (ret == null)
                throw new InvalidOperationException(
                    "Riot returned an empty storefront response."
                );

            if (ret.SkinsPanelLayout?.SingleItemOffers == null ||
                ret.SkinsPanelLayout.SingleItemOffers.Count < 4)
            {
                throw new InvalidOperationException(
                    "Riot returned a storefront response without four daily offers."
                );
            }

            ret.FormattedSkinsPanelLayout = FormatOffers(au, ret);

            ret.SkinsPanelLayout.FormattedSingleItemOffersRemainingDuration =
                FormatDuration(
                    ret.SkinsPanelLayout
                        .SingleItemOffersRemainingDurationInSeconds
                );

            if (ret.FeaturedBundle != null)
            {
                ret.FeaturedBundle.FormattedBundleRemainingDuration =
                    FormatDuration(
                        ret.FeaturedBundle
                            .BundleRemainingDurationInSeconds
                    );
            }

            ret.StatusCode = 200;

            return ret;
        }


        // =========================
        // Formatting
        // =========================

        private static string[,] FormatOffers(Auth au, Store store)
        {
            var formattedOffers = new string[4, 2];

            var offers = store.SkinsPanelLayout.SingleItemStoreOffers;

            for (int i = 0; i < 4; i++)
            {
                string offerId =
                    store.SkinsPanelLayout.SingleItemOffers[i];

                var offer = offers?
                    .FirstOrDefault(x => x.OfferID == offerId);

                var reward = offer?.Rewards?.FirstOrDefault();

                if (reward == null)
                    continue;

                Content content = Content.Search(
                    au,
                    reward.ItemID
                );

                if (content?.data == null)
                    continue;

                formattedOffers[i, 0] =
                    content.data.displayName;

                formattedOffers[i, 1] =
                    content.data.displayIcon;
            }

            return formattedOffers;
        }

        private static string FormatDuration(int seconds)
        {
            return TimeSpan
                .FromSeconds(seconds)
                .ToString(@"dd\:hh\:mm\:ss");
        }
    }
}