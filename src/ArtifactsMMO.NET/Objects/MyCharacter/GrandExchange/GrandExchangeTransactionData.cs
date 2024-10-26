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
            GrandExchangeTransaction transaction)
            : base(cooldown, character)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Grand Exchange transaction
        /// </summary>
        public GrandExchangeTransaction Transaction { get; }
    }
}
