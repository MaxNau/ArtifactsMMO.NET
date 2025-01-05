using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Objects.Events;
using System.Text.Json.Serialization;

using ArtifactsMMO.NET.Objects.Achievements;

namespace ArtifactsMMO.NET.Objects.Notifications
{
    /// <summary>
    /// Notification about an achievement unlock
    /// </summary>
    public class AchievementUnlockNotification : ServerNotification
    {
        /// <summary>
        /// The achievement
        /// </summary>
        public Achievement Data { get; }

        /// <summary>
        /// Construct a new event removed notification
        /// </summary>
        /// <param name="type">Notification type</param>
        /// <param name="data">The achievement</param>
        [JsonConstructor]
        public AchievementUnlockNotification(NotificationType type, Achievement data)
            : base(type)
        {
            Data = data;
        }
    }
}
