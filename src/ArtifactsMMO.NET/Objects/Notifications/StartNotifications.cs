using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.WebSockets;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Notifications
{
    /// <summary>
    /// This message is sent to the server to indicate which notifications type the client is interested to
    /// </summary>
    public class StartNotifications : IRealTimeMessage
    {
        /// <summary>
        /// The token authenticate the current user
        /// </summary>
        public string Token { get; }

        /// <summary>
        /// The notification types to which the client wants to subscribe
        /// </summary>
        public IEnumerable<NotificationType> Subscriptions { get; }


        /// <summary>
        /// Construct a new start notification message
        /// </summary>
        /// <param name="token">The auth token</param>
        /// <param name="subscriptions">The subscription types</param>
        [JsonConstructor]
        public StartNotifications(string token, IEnumerable<NotificationType> subscriptions)
        {
            Token = token;
            Subscriptions = subscriptions;
        }
    }
}
