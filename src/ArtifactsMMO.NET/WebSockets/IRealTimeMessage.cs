using ArtifactsMMO.NET.Objects.Notifications;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.WebSockets
{

    /// <summary>
    /// Represent any message sent/received through websocket
    /// Note: all sent message should be specified as JsonDerivedType. It's not required form received message that are deserialized explicitly with the message factory.
    /// </summary>
    //Really not a big fan of this, but Net's JsonSerializer doesn't manage to deserialize IRealTimeMessage without knowing the subtypes
    [JsonDerivedType(typeof(StartNotifications))]
    public interface IRealTimeMessage
    {
    }
}
