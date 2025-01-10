using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.WebSockets;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Notifications
{
    /// <summary>
    /// Base abstraction for all the notification
    /// </summary>
    public abstract class ServerNotification : IRealTimeMessage
    {
        /// <summary>
        /// This notification type represent what kind of notification the client receives.
        /// The original value is used to create the correct specific notification
        /// </summary>
        public NotificationType Type { get; }

        /// <summary>
        /// Construct a new notification
        /// </summary>
        /// <param name="type">The server notification type</param>
        [JsonConstructor]
        protected ServerNotification(NotificationType type)
        {
            Type = type;
        }
    }
}
