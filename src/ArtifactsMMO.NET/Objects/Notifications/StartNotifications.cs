using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.WebSockets;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Notifications
{
    internal class StartNotifications : IRealTimeMessage
    {
        public string Token { get; }
        public IEnumerable<NotificationType> Subscriptions { get; }

        [JsonConstructor]
        public StartNotifications(string token, IEnumerable<NotificationType> subscriptions)
        {
            Token = token;
            Subscriptions = subscriptions;
        }
    }
}
