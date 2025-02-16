using ArtifactsMMO.NET.Objects.Characters;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyCharacter.Npc
{
    /// <summary>
    /// Represents the data related to a character's bank item transaction action.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="ActionData"/>.
    /// </remarks>
    public class NpcMerchantTransaction : ActionData
    {
        internal NpcMerchantTransaction() { }

        [JsonConstructor]
        internal NpcMerchantTransaction(NpcItemTransaction transaction, Cooldown cooldown, Character character)
            : base(cooldown, character)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Transaction details.
        /// </summary>
        public NpcItemTransaction Transaction { get; }
    }
}
