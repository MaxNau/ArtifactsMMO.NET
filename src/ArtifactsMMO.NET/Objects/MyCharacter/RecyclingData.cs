using ArtifactsMMO.NET.Objects.Characters;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyCharacter
{
    /// <summary>
    /// Represents the data related to a recycling action.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="ActionData"/>.
    /// </remarks>
    public class RecyclingData : ActionData
    {
        internal RecyclingData() { }

        [JsonConstructor]
        internal RecyclingData(RecyclingItems details, Cooldown cooldown, Character character)
            : base(cooldown, character)
        {
            Details = details;
        }

        /// <summary>
        /// Recycling items details
        /// </summary>
        public RecyclingItems Details { get; }
    }
}
