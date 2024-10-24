using ArtifactsMMO.NET.Objects.Characters;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyCharacter
{
    /// <summary>
    /// Represents the data related to a character's gathering or crafting action.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="ActionData"/>.
    /// </remarks>
    public class SkillData : ActionData
    {
        internal SkillData() { }

        [JsonConstructor]
        internal SkillData(Cooldown cooldown, SkillInfo details, Character character)
            : base(cooldown, character)
        {
            Details = details;
        }

        /// <summary>
        /// Craft details.
        /// </summary>
        public SkillInfo Details { get; }
    }
}
