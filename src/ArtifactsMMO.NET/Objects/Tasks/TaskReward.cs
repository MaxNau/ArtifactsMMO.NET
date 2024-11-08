using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Tasks
{
    /// <summary>
    /// Task reward details
    /// </summary>
    public class TaskReward
    {
        internal TaskReward() { }

        [JsonConstructor]
        internal TaskReward(string code, int minQuantity, int maxQuantity, int rate)
        {
            Code = code;
            MinQuantity = minQuantity;
            MaxQuantity = maxQuantity;
            Rate = rate;
        }

        /// <summary>
        /// Item code.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Minimum quantity of item.
        /// </summary>
        public int MinQuantity { get; }

        /// <summary>
        /// Maximum quantity of item.
        /// </summary>
        public int MaxQuantity { get; }

        /// <summary>
        /// Chance rate. (1/rate)
        /// </summary>
        public int Rate { get; }
    }
}
