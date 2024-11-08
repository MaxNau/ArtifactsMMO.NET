using ArtifactsMMO.NET.Objects.Characters;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyCharacter.GrandExchange
{
    /// <summary>
    /// Grand Exchange order transaction data
    /// </summary>
    public class GrandExchangeOrderTransaction : ActionData
    {
        internal GrandExchangeOrderTransaction() { }

        [JsonConstructor]
        internal GrandExchangeOrderTransaction(GrandExchangeOrderCreated order, Cooldown cooldown, Character character)
            : base(cooldown, character)
        {
            Order = order;
        }

        /// <summary>
        /// Order details.
        /// </summary>
        public GrandExchangeOrderCreated Order { get; }
    }
}
