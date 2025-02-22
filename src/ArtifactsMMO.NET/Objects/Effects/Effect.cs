using ArtifactsMMO.NET.Enums;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Effects
{
    /// <summary>
    /// Effect details
    /// </summary>
    public class Effect
    {
        internal Effect() { }

        [JsonConstructor]
        internal Effect(string name, string code, string description, EffectType type, EffectSubtype subtype)
        {
            Name = name;
            Code = code;
            Description = description;
            Type = type;
            Subtype = subtype;
        }

        /// <summary>
        /// Name of the effect
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The code of the effect. This is the effect's unique identifier (ID).
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Description of the effect. This is a brief description of the effect.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Type of the effect.
        /// </summary>
        public EffectType Type { get; }

        /// <summary>
        /// Subtype of the effect.
        /// </summary>
        public EffectSubtype Subtype { get; }
    }
}
