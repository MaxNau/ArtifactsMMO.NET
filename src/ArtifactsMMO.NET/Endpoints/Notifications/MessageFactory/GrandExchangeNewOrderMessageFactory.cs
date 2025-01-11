using ArtifactsMMO.NET.Objects.Notifications;
using ArtifactsMMO.NET.WebSockets;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ArtifactsMMO.NET.Endpoints.Notifications.MessageFactory
{
    internal class GrandExchangeNewOrderMessageFactory : IMessageFactory<ServerNotification>
    {
        public bool IsApplicable(string messageText)
        {
            JsonNode jsonNode = JsonObject.Parse(messageText);
            return jsonNode["type"]?.Deserialize<string>() == "grandexchange_neworder";
        }

        public ServerNotification Deserialize(string messageText, JsonSerializerOptions jsonSerializerOptions)
        {
            GrandExchangeNewOrderNotification notification = JsonSerializer.Deserialize<GrandExchangeNewOrderNotification>(messageText, jsonSerializerOptions);
            return notification;
        }
    }
}
