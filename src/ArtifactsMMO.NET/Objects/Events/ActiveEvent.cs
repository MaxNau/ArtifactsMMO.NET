using ArtifactsMMO.NET.Objects.Maps;
using System;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Events
{
    /// <summary>
    /// Game active event details
    /// </summary>
    public class ActiveEvent
    {
        internal ActiveEvent() { }

        [JsonConstructor]
        internal ActiveEvent(string name, string code, Map map, string previousSkin, long duration,
            DateTimeOffset expiration, DateTimeOffset createdAt)
        {
            Name = name;
            Code = code;
            Map = map;
            PreviousSkin = previousSkin;
            Duration = duration;
            Expiration = expiration;
            CreatedAt = createdAt;
        }

        /// <summary>
        /// Name of the event.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Code of the event. This is the event's unique identifier (ID).
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Map of the event.
        /// </summary>
        public Map Map { get; }

        /// <summary>
        /// Previous map skin.
        /// </summary>
        public string PreviousSkin { get; }

        /// <summary>
        /// Duration in minutes.
        /// </summary>
        public long Duration { get; }

        /// <summary>
        /// Expiration datetime.
        /// </summary>
        public DateTimeOffset Expiration { get; }

        /// <summary>
        /// Start datetime.
        /// </summary>
        public DateTimeOffset CreatedAt { get; }
    }
}
