using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Events
{
    /// <summary>
    /// Content of the event
    /// </summary>
    public class EventConten
    {
        internal EventConten()
        {

        }

        [JsonConstructor]
        internal EventConten(string type, string code)
        {
            Type = type;
            Code = code;
        }

        /// <summary>
        /// Type of the event.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Code content.
        /// </summary>
        public string Code { get; }
    }
}
