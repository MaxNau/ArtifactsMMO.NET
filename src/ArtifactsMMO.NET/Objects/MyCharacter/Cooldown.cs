using ArtifactsMMO.NET.Enums;
using System;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyCharacter
{
    /// <summary>
    /// Cooldown details
    /// </summary>
    public class Cooldown
    {
        internal Cooldown() { }

        [JsonConstructor]
        internal Cooldown(int totalSeconds, int remainingSeconds, DateTimeOffset startedAt,
            DateTimeOffset expiration, CooldownReason reason)
        {
            TotalSeconds = totalSeconds;
            RemainingSeconds = remainingSeconds;
            StartedAt = startedAt;
            Expiration = expiration;
            Reason = reason;
        }

        /// <summary>
        /// The total seconds of the cooldown.
        /// </summary>
        public int TotalSeconds { get; }

        /// <summary>
        /// The remaining seconds of the cooldown.
        /// </summary>
        public int RemainingSeconds { get; }

        /// <summary>
        /// The start of the cooldown.
        /// </summary>
        public DateTimeOffset StartedAt { get; }

        /// <summary>
        /// The expiration of the cooldown.
        /// </summary>
        public DateTimeOffset Expiration { get; }

        /// <summary>
        /// The reason of the cooldown.
        /// </summary>
        public CooldownReason Reason { get; }
    }
}
