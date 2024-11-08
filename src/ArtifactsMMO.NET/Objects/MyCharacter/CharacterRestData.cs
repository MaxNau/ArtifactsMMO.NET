using ArtifactsMMO.NET.Objects.Characters;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyCharacter
{
    /// <summary>
    /// Represents the data related to a character's rest action.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="ActionData"/>.
    /// </remarks>
    public class CharacterRestData : ActionData
    {
        internal CharacterRestData() { }

        [JsonConstructor]
        internal CharacterRestData(int hpRestored, Cooldown cooldown, Character character)
            : base(cooldown, character)
        {
            HpRestored = hpRestored;
        }

        /// <summary>
        /// The amount of HP restored.
        /// </summary>
        public int HpRestored { get; }
    }
}
