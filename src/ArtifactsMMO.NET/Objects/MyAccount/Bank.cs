using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyAccount
{
    /// <summary>
    /// Bank details
    /// </summary>
    public class Bank
    {
        internal Bank() { }

        [JsonConstructor]
        internal Bank(int slots, int expansions, int nextExpansionCost, int gold)
        {
            Slots = slots;
            Expansions = expansions;
            NextExpansionCost = nextExpansionCost;
            Gold = gold;
        }

        /// <summary>
        /// Maximum slots in your bank.
        /// </summary>
        public int Slots { get; }

        /// <summary>
        /// Bank expansions.
        /// </summary>
        public int Expansions { get; }

        /// <summary>
        /// Next expansion cost.
        /// </summary>
        public int NextExpansionCost { get; }

        /// <summary>
        /// Quantity of gold in your bank.
        /// </summary>
        public int Gold { get; }
    }
}
