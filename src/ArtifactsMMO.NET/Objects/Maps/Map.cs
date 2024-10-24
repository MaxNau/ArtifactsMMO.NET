using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Maps
{
    /// <summary>
    /// Map details
    /// </summary>
    public class Map
    {
        internal Map() { }

        [JsonConstructor]
        internal Map(string name, string skin, int x, int y, MapContent content)
        {
            Name = name;
            Skin = skin;
            X = x;
            Y = y;
            Content = content;
        }

        /// <summary>
        /// Name of the map.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Skin of the map.
        /// </summary>
        public string Skin { get; }

        /// <summary>
        /// Position X of the map.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Position Y of the map.
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Content of the map.
        /// </summary>
        public MapContent Content { get; }
    }
}
