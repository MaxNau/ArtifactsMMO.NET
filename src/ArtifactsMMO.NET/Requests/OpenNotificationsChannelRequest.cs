using ArtifactsMMO.NET.Enums;
using System.Collections.Generic;

namespace ArtifactsMMO.NET.Requests
{
    /// <summary>
    /// Open a new channel for notifications for websockets
    /// </summary>
    public class OpenNotificationsChannelRequest : IRequest
    {
        /// <summary>
        /// The notification types that will get subscribed
        /// </summary>
        public IEnumerable<NotificationType> NotificationTypes { get; }

        public OpenNotificationsChannelRequest(params NotificationType[] notificationTypes)
        {
            NotificationTypes = notificationTypes;
        }
    }
}
