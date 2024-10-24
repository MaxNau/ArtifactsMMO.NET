using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Objects.Items;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Crafting
{
    /// <summary>
    /// Craft details
    /// </summary>
    public class Craft
    {
        internal Craft() { }

        [JsonConstructor]
        internal Craft(CraftSkill skill, int level, IReadOnlyCollection<SimpleItem> items, int quantity)
        {
            Skill = skill;
            Level = level;
            Items = items;
            Quantity = quantity;
        }

        /// <summary>
        /// Skill required to craft the item.
        /// </summary>
        public CraftSkill Skill { get; }

        /// <summary>
        /// The skill level required to craft the item.
        /// </summary>
        public int Level { get; }

        /// <summary>
        /// List of items required to craft the item.
        /// </summary>
        public IReadOnlyCollection<SimpleItem> Items { get; }

        /// <summary>
        /// Quantity of items crafted.
        /// </summary>
        public int Quantity { get; }
    }
}
