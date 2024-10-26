using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Loot
{
    /// <summary>
    /// Monster or resource drop details
    /// </summary>
    public class DropDetails
    {
        internal DropDetails() { }

        [JsonConstructor]
        internal DropDetails(string code, long rate, long minQuantity, long maxQuantity)
        {
            Code = code;
            Rate = rate;
            MinQuantity = minQuantity;
            MaxQuantity = maxQuantity;
        }

        /// <summary>
        /// The code of the item.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Chance rate.
        /// </summary>
        public long Rate { get; }

        /// <summary>
        /// Minimum quantity.
        /// </summary>
        public long MinQuantity { get; }

        /// <summary>
        /// Maximum quantity.
        /// </summary>
        public long MaxQuantity { get; }
    }
}
