using ArtifactsMMO.NET.Objects.Characters;
using ArtifactsMMO.NET.Objects.Loot;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyCharacter.Bank
{
    /// <summary>
    /// Represents the data related to a character's bank gold transaction action.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="ActionData"/>.
    /// </remarks>
    public class BankGoldTransaction : ActionData
    {
        internal BankGoldTransaction() { }

        [JsonConstructor]
        internal BankGoldTransaction(Cooldown cooldown, Gold bank, Character character)
            : base(cooldown, character)
        {
            Bank = bank;
        }

        /// <summary>
        /// Bank details.
        /// </summary>
        public Gold Bank { get; }
    }
}
