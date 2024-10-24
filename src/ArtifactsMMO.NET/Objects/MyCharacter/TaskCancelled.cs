using ArtifactsMMO.NET.Objects.Characters;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyCharacter
{
    /// <summary>
    /// Represents the data related to a cancel task action.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="ActionData"/>.
    /// </remarks>
    public class TaskCancelled : ActionData
    {
        internal TaskCancelled() { }

        [JsonConstructor]
        internal TaskCancelled(Cooldown cooldown, Character character) : base(cooldown, character)
        {
        }
    }
}
