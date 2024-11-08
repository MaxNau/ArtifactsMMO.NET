using ArtifactsMMO.NET.Objects.Characters;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyCharacter.GrandExchange
{
    /// <summary>
    /// Grand Exchange transaction data
    /// </summary>
    public class GrandExchangeTransactionData : ActionData
    {
        internal GrandExchangeTransactionData() { }

        [JsonConstructor]
        internal GrandExchangeTransactionData(Cooldown cooldown, Character character,
            GrandExchangeTransaction order)
            : base(cooldown, character)
        {
            Order = order;
        }

        /// <summary>
        /// Grand Exchange transaction
        /// </summary>
        public GrandExchangeTransaction Order { get; }
    }
}
