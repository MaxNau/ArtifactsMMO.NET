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
        internal Effect(string code, int value)
        {
            Code = code;
            Value = value;
        }

        /// <summary>
        /// Effect code.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Effect value.
        /// </summary>
        public int Value { get; }
    }
}
