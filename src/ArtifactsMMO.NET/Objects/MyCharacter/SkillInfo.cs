using ArtifactsMMO.NET.Objects.Items;
using ArtifactsMMO.NET.Objects.Loot;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyCharacter
{
    /// <summary>
    /// Skill information
    /// </summary>
    public class SkillInfo
    {
        internal SkillInfo() { }

        [JsonConstructor]
        internal SkillInfo(int xp, IReadOnlyCollection<Drop> items)
        {
            Xp = xp;
            Items = items;
        }

        /// <summary>
        /// The amount of xp gained.
        /// </summary>
        public int Xp { get; }

        /// <summary>
        /// Objects received.
        /// </summary>
        public IReadOnlyCollection<Drop> Items { get; }
    }
}
