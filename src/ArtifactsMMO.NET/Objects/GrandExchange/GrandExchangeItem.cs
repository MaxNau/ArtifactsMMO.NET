using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.GrandExchange
{
    /// <summary>
    /// Grand Exchange item details
    /// </summary>
    public class GrandExchangeItem
    {
        internal GrandExchangeItem() { }

        [JsonConstructor]
        internal GrandExchangeItem(string code, int stock, int? sellPrice, int? buyPrice, int maxQuantity)
        {
            Code = code;
            Stock = stock;
            SellPrice = sellPrice;
            BuyPrice = buyPrice;
            MaxQuantity = maxQuantity;
        }

        /// <summary>
        /// Item code.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Item stock.
        /// </summary>
        public int Stock { get; }

        /// <summary>
        /// The item's selling price.
        /// </summary>
        public int? SellPrice { get; }

        /// <summary>
        /// The item's buying price.
        /// </summary>
        public int? BuyPrice { get; }

        /// <summary>
        /// The number of items you can buy or sell at the same time.
        /// </summary>
        public int MaxQuantity { get; }
    }
}
