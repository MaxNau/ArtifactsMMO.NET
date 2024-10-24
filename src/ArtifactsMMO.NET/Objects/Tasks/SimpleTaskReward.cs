using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Tasks
{
    /// <summary>
    /// Brief task reward details
    /// </summary>
    public class SimpleTaskReward
    {
        internal SimpleTaskReward() { }

        [JsonConstructor]
        internal SimpleTaskReward(string code, int quantity)
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
