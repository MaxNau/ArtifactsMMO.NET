using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Items
{
    /// <summary>
    /// Lightweight item information
    /// </summary>
    public class SimpleItem
    {
        internal SimpleItem() { }

        [JsonConstructor]
        internal SimpleItem(string code, int quantity)
        {
            Code = code;
            Quantity = quantity;
        }

        /// <summary>
        /// Item code.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Item quantity.
        /// </summary>
        public int Quantity { get; }
    }
}
