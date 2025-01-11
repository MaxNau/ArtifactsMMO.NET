using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Objects.Events;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Notifications
{
    /// <summary>
    /// Notification about a removed event
    /// </summary>
    public class EventRemovedNotification : ServerNotification
    {
        /// <summary>
        /// The active event
        /// </summary>
        public ActiveEvent Data { get; }

        /// <summary>
        /// Construct a new event removed notification
        /// </summary>
        /// <param name="type">Notification type</param>
        /// <param name="data">Active event</param>
        [JsonConstructor]
        public EventRemovedNotification(NotificationType type, ActiveEvent data)
            : base(type)
        {
            Data = data;
        }
    }
}
