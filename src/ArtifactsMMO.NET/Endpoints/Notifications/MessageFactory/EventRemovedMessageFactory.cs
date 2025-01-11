using ArtifactsMMO.NET.Objects.Notifications;
using ArtifactsMMO.NET.WebSockets;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ArtifactsMMO.NET.Endpoints.Notifications.MessageFactory
{
    internal class EventRemovedMessageFactory : IMessageFactory<ServerNotification>
    {
        public bool IsApplicable(string messageText)
        {
            JsonNode jsonNode = JsonObject.Parse(messageText);
            return jsonNode["type"]?.Deserialize<string>() == "event_removed";
        }

        public ServerNotification Deserialize(string messageText, JsonSerializerOptions jsonSerializerOptions)
        {
            EventRemovedNotification notification = JsonSerializer.Deserialize<EventRemovedNotification>(messageText, jsonSerializerOptions);
            return notification;
        }
    }
}
