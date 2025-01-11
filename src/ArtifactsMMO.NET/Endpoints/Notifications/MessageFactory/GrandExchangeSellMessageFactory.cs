using ArtifactsMMO.NET.Objects.Notifications;
using ArtifactsMMO.NET.WebSockets;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ArtifactsMMO.NET.Endpoints.Notifications.MessageFactory
{
    internal class GrandExchangeSellMessageFactory : IMessageFactory<ServerNotification>
    {
        public bool IsApplicable(string messageText)
        {
            JsonNode jsonNode = JsonObject.Parse(messageText);
            return jsonNode["type"]?.Deserialize<string>() == "grandexchange_sell";
        }

        public ServerNotification Deserialize(string messageText, JsonSerializerOptions jsonSerializerOptions)
        {
            GrandExchangeSellNotification notification = JsonSerializer.Deserialize<GrandExchangeSellNotification>(messageText, jsonSerializerOptions);
            return notification;
        }
    }
}
