using ArtifactsMMO.NET.Objects.Characters;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyCharacter.Bank
{
    /// <summary>
    /// Represents bank extension transaction details associated with the buy bank expansion action
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="ActionData"/>.
    /// </remarks>
    public class BankExtensionTransaction : ActionData
    {
        internal BankExtensionTransaction() { }

        [JsonConstructor]
        internal BankExtensionTransaction(BankExtension transaction, Cooldown cooldown, Character character)
            : base(cooldown, character)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// <see cref="BankExtension"/> associated with this transaction.
        /// </summary>
        public BankExtension Transaction { get; }
    }
}
