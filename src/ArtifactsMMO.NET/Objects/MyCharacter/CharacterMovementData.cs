using ArtifactsMMO.NET.Objects.Characters;
using ArtifactsMMO.NET.Objects.Maps;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyCharacter
{
    /// <summary>
    /// Represents the data related to a character's movement action.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="ActionData"/>.
    /// </remarks>
    public class CharacterMovementData : ActionData
    {
        internal CharacterMovementData() { }

        [JsonConstructor]
        internal CharacterMovementData(Cooldown cooldown, Map destination, Character character)
            : base (cooldown, character)
        {
            Destination = destination;
        }

        /// <summary>
        /// Destination details.
        /// </summary>
        public Map Destination { get; }
    }
}
