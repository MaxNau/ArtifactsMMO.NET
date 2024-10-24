using ArtifactsMMO.NET.Objects.Characters;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyCharacter.Fight
{
    /// <summary>
    /// Represents the data related to a character's fight action.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="ActionData"/>.
    /// </remarks>
    public class CharacterFightData : ActionData
    {
        internal CharacterFightData() { }

        [JsonConstructor]
        internal CharacterFightData(Cooldown cooldown, Fight fight, Character character)
            : base(cooldown, character)
        {
            Fight = fight;
        }

        /// <summary>
        /// Fight details.
        /// </summary>
        public Fight Fight { get; }
    }
}
