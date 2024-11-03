using ArtifactsMMO.NET.Enums;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Maps
{
    /// <summary>
    /// Map content details
    /// </summary>
    public class MapContent
    {
        internal MapContent() { }

        [JsonConstructor]
        internal MapContent(MapContentType type, string code)
        {
            Type = type;
            Code = code;
        }

        /// <summary>
        /// Type of the content.
        /// </summary>
        public MapContentType Type { get; }

        /// <summary>
        /// Code of the content.
        /// </summary>
        public string Code { get; }
    }
}
