using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Badges
{
    /// <summary>
    /// Badge Condition details
    /// </summary>
    public class BadgeCondition
    {
        internal BadgeCondition() { }

        [JsonConstructor]
        internal BadgeCondition(string code, int? quantity)
        {
            Code = code;
            Quantity = quantity;
        }

        /// <summary>
        /// Code of the condition.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Quantity of the condition (if any).
        /// </summary>
        public int? Quantity { get; }
    }
}
