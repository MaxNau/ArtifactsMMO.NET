using System;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Server
{
    /// <summary>
    /// Server announcement
    /// </summary>
    public class Announcement
    {
        internal Announcement() { }

        [JsonConstructor]
        internal Announcement(string message, DateTimeOffset createdAt)
        {
            Message = message;
            CreatedAt = createdAt;
        }

        /// <summary>
        /// Announcement text.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Datetime of the announcement.
        /// </summary>
        public DateTimeOffset CreatedAt { get; }
    }
}
