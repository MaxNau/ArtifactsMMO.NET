using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Effects
{
    /// <summary>
    ///  Effect details
    /// </summary>
    public class Effect
    {
        internal Effect() { }

        [JsonConstructor]
        internal Effect(string name, int value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Effect name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Effect value.
        /// </summary>
        public int Value { get; }
    }
}
