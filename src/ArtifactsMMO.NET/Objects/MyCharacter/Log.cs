using System;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyCharacter
{
    /// <summary>
    /// Character log
    /// </summary>
    public class Log
    {
        internal Log() { }

        [JsonConstructor]
        internal Log(string character, string account, string type, string description, object content,
            int cooldown, DateTimeOffset? cooldownExpiration, DateTimeOffset createdAt)
        {
            Character = character;
            Account = account;
            Type = type;
            Description = description;
            Content = content;
            Cooldown = cooldown;
            CooldownExpiration = cooldownExpiration;
            CreatedAt = createdAt;
        }

        /// <summary>
        /// Character name.
        /// </summary>
        public string Character { get; }

        /// <summary>
        /// Account character.
        /// </summary>
        public string Account { get; }

        /// <summary>
        /// Type of action.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Description of action.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Content of action.
        /// </summary>
        public object Content { get; }

        /// <summary>
        /// Cooldown in seconds.
        /// </summary>
        public int Cooldown { get; }

        /// <summary>
        /// Datetime of cooldown expiration.
        /// </summary>
        public DateTimeOffset? CooldownExpiration { get; }

        /// <summary>
        /// Datetime of creation.
        /// </summary>
        public DateTimeOffset CreatedAt { get; }
    }
}
