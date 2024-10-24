using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Loot
{
    /// <summary>
    /// Drop information
    /// </summary>
    public class Drop
    {
        internal Drop() { }

        [JsonConstructor]
        internal Drop(string code, int quantity)
        {
            Code = code;
            Quantity = quantity;
        }

        /// <summary>
        /// The code of the item.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// The quantity of the item.
        /// </summary>
        public int Quantity { get; }
    }
}
