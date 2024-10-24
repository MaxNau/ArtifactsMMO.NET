using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Tasks
{
    /// <summary>
    /// Task reward details
    /// </summary>
    public class TaskTrade
    {
        internal TaskTrade() { }

        [JsonConstructor]
        internal TaskTrade(string code, int quantity)
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
