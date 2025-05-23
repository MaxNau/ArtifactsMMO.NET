﻿using ArtifactsMMO.NET.Objects.Notifications;
using ArtifactsMMO.NET.WebSockets;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ArtifactsMMO.NET.Endpoints.Notifications.MessageFactory
{
    internal class EventSpawnMessageFactory : IMessageFactory<ServerNotification>
    {
        public bool IsApplicable(string messageText)
        {
            JsonNode jsonNode = JsonObject.Parse(messageText);
            return jsonNode["type"]?.Deserialize<string>() == "event_spawn";
        }

        public ServerNotification Deserialize(string messageText, JsonSerializerOptions jsonSerializerOptions)
        {
            EventSpawnNotification notification = JsonSerializer.Deserialize<EventSpawnNotification>(messageText, jsonSerializerOptions);
            return notification;
        }
    }
}
