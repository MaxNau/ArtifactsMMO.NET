using ArtifactsMMO.NET.Objects.Crafting;
using ArtifactsMMO.NET.Objects.Effects;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Items
{
    /// <summary>
    /// Item information
    /// </summary>
    public class Item
    {
        internal Item() { }

        [JsonConstructor]
        internal Item(string name, string code, int level, string type, string subtype, string description,
            IReadOnlyCollection<Effect> effects, Craft craft)
        {
            Name = name;
            Code = code;
            Level = level;
            Type = type;
            Subtype = subtype;
            Description = description;
            Effects = effects;
            Craft = craft;
        }

        /// <summary>
        /// Item name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Item code. This is the item's unique identifier (ID).
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Item level.
        /// </summary>
        public int Level { get; }

        /// <summary>
        /// Item type.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Item subtype.
        /// </summary>
        public string Subtype { get; }

        /// <summary>
        /// Item description.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// List of object effects. For equipment, it will include item stats. (optional)
        /// </summary>
        public IReadOnlyCollection<Effect> Effects { get; }

        /// <summary>
        /// Craft information. If applicable. (optional)
        /// </summary>
        public Craft Craft { get; }
    }
}
