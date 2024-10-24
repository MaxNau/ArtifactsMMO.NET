using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Objects.Loot;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Resources
{
    /// <summary>
    /// Recouse details
    /// </summary>
    public class Resource
    {
        internal Resource() { }

        [JsonConstructor]
        internal Resource(string name, string code, GatheringSkill skill, long level,
            IReadOnlyCollection<DropDetails> drops)
        {
            Name = name;
            Code = code;
            Skill = skill;
            Level = level;
            Drops = drops;
        }

        /// <summary>
        /// The name of the resource
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The code of the resource. This is the resource's unique identifier (ID).
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// The skill required to gather this resource.
        /// </summary>
        public GatheringSkill Skill { get; }

        /// <summary>
        /// The skill level required to gather this resource.
        /// </summary>
        public long Level { get; }

        /// <summary>
        /// The drops of this resource.
        /// </summary>
        public IReadOnlyCollection<DropDetails> Drops { get; }
    }
}
