using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Server
{
    /// <summary>
    /// Status of the game server
    /// </summary>
    public class ServerStatus
    {
        internal ServerStatus() { }

        [JsonConstructor]
        internal ServerStatus(string status, string version, long maxLevel, long charactersOnline,
            DateTimeOffset serverTime, IReadOnlyCollection<Announcement> announcements,
            DateTimeOffset lastWipe, string nextWipe)
        {
            Status = status;
            Version = version;
            MaxLevel = maxLevel;
            CharactersOnline = charactersOnline;
            ServerTime = serverTime;
            Announcements = announcements;
            LastWipe = lastWipe;
            NextWipe = nextWipe;
        }

        /// <summary>
        /// Server status
        /// </summary>
        public string Status { get; }

        /// <summary>
        /// Server version.
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// Maximum level.
        /// </summary>
        public long MaxLevel { get; }

        /// <summary>
        /// Characters online.
        /// </summary>
        public long CharactersOnline { get; }

        /// <summary>
        /// Server time.
        /// </summary>
        public DateTimeOffset ServerTime { get; }

        /// <summary>
        /// Server announcements.
        /// </summary>
        public IReadOnlyCollection<Announcement> Announcements { get; }

        /// <summary>
        /// Last server wipe.
        /// </summary>
        public DateTimeOffset LastWipe { get; }

        /// <summary>
        /// Next server wipe.
        /// </summary>
        public string NextWipe { get; }
    }
}
