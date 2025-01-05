using ArtifactsMMO.NET.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

using ArtifactsMMO.NET.Objects.Notifications;

namespace ArtifactsMMO.NET.WebSockets
{
    //Really not a big fan of this, but Net's JsonSerializer doesn't manage to deserialize IRealTimeMessage without knowing the subtypes
    [JsonDerivedType(typeof(StartNotifications))]
    [JsonDerivedType(typeof(ServerNotification))]
    public interface IRealTimeMessage
    {
    }
}
