using ArtifactsMMO.NET.Objects.Notifications;
using ArtifactsMMO.NET.WebSockets;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ArtifactsMMO.NET.Endpoints.Notifications.MessageFactory
{
    internal class AchievementUnlockMessageFactory : IMessageFactory<ServerNotification>
    {
        public bool IsApplicable(string messageText)
        {
            JsonNode jsonNode = JsonObject.Parse(messageText);
            return jsonNode["type"]?.Deserialize<string>() == "achievement_unlocked";
        }

        public ServerNotification Deserialize(string messageText, JsonSerializerOptions jsonSerializerOptions)
        {
            AchievementUnlockNotification notification = JsonSerializer.Deserialize<AchievementUnlockNotification>(messageText, jsonSerializerOptions);
            return notification;
        }
    }
}
