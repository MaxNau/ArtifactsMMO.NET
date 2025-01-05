using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

using ArtifactsMMO.NET.Objects.Notifications;
using ArtifactsMMO.NET.WebSockets;

namespace ArtifactsMMO.NET.Endpoints.Notifications.MessageFactory
{
    internal class TestSpawnMessageFactory : IMessageFactory<ServerNotification>
    {
        public bool IsApplicable(string messageText)
        {
            JsonNode jsonNode = JsonObject.Parse(messageText);
            return jsonNode["type"]?.Deserialize<string>() == "test";
        }

        public ServerNotification Deserialize(string messageText, JsonSerializerOptions jsonSerializerOptions)
        {
            TestNotification notification = JsonSerializer.Deserialize<TestNotification>(messageText, jsonSerializerOptions);
            return notification;
        }
    }
}
