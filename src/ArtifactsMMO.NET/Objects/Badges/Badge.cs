using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Badges
{
    /// <summary>
    /// Details of a badge
    /// </summary>
    public class Badge
    {
        internal Badge() { }

        [JsonConstructor]
        internal Badge(string code, int? season, string description, IReadOnlyCollection<BadgeCondition> conditions)
        {
            Code = code;
            Season = season;
            Description = description;
            Conditions = conditions;
        }

        /// <summary>
        /// Code of the badge. This is the badge's unique identifier (ID).
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Season of the badge.
        /// </summary>
        public int? Season { get; }

        /// <summary>
        /// Description of the badge.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Conditions to get the badge.
        /// </summary>
        public IReadOnlyCollection<BadgeCondition> Conditions { get; }
    }
}
