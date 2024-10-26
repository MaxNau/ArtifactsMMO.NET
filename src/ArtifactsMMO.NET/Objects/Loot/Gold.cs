using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Loot
{
    /// <summary>
    /// Gold details
    /// </summary>
    public class Gold
    {
        internal Gold() { }

        [JsonConstructor]
        internal Gold(int quantity)
        {
            Quantity = quantity;
        }

        /// <summary>
        /// Quantity of gold.
        /// </summary>
        public int Quantity { get; }
    }
}
