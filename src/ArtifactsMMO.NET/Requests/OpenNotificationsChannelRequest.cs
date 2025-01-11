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

        /// <summary>
        /// Constructs a new request to open a websocket, with a given list of notification types to register
        /// </summary>
        /// <param name="notificationTypes"></param>
        public OpenNotificationsChannelRequest(params NotificationType[] notificationTypes)
        {
            NotificationTypes = notificationTypes;
        }
    }
}
