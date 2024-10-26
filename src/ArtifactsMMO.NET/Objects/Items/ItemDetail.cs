using ArtifactsMMO.NET.Objects.GrandExchange;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Items
{
    /// <summary>
    /// IItem details
    /// </summary>
    public class ItemDetail
    {
        internal ItemDetail() { }

        [JsonConstructor]
        internal ItemDetail(Item item, GrandExchangeItem ge)
        {
            Item = item;
            Ge = ge;
        }

        /// <summary>
        /// Item
        /// </summary>
        public Item Item { get; }

        /// <summary>
        /// Grand Exchange information. If applicable.
        /// </summary>
        public GrandExchangeItem Ge { get; }
    }
}
