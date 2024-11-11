using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Events
{
    /// <summary>
    /// Event map details
    /// </summary>
    public class EventMap
    {
        internal EventMap() { }

        [JsonConstructor]
        internal EventMap(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Position X of the map.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Position Y of the map.
        /// </summary>
        public int Y { get; }
    }
}
