using System.Text.Json.Serialization;

using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.WebSockets;

namespace ArtifactsMMO.NET.Objects.Notifications
{
    public class ServerNotification : IRealTimeMessage
    {
        public NotificationType Type { get; }

        [JsonConstructor]
        public ServerNotification(NotificationType type)
        {
            Type = type;
        }
    }
}
