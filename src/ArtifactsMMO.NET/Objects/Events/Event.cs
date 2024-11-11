using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Events
{
    /// <summary>
    /// Game event details
    /// </summary>
    public class Event
    {
        internal Event() { }

        [JsonConstructor]
        internal Event(string code, string name, string skin, long duration, int rate,
            EventConten content, IReadOnlyCollection<EventMap> maps)
        {
            Name = name;
            Duration = duration;
            Code = code;
            Skin = skin;
            Rate = rate;
            Content = content;
            Maps = maps;
        }

        /// <summary>
        /// Code of the event. This is the event's unique identifier (ID).
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Name of the event.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Map skin of the event.
        /// </summary>
        public string Skin { get; }

        /// <summary>
        /// Duration in minutes.
        /// </summary>
        public long Duration { get; }

        /// <summary>
        /// Rate spawn of the event. (1/rate every minute)
        /// </summary>
        public int Rate { get; }

        /// <summary>
        /// Content of the event.
        /// </summary>
        public EventConten Content { get; }

        /// <summary>
        /// Map list of the event.
        /// </summary>
        public IReadOnlyCollection<EventMap> Maps { get; }
    }
}
