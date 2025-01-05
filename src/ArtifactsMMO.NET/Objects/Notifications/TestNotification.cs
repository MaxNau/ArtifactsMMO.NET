using System.Text.Json.Serialization;

using ArtifactsMMO.NET.Enums;

namespace ArtifactsMMO.NET.Objects.Notifications
{
    internal class TestNotification : ServerNotification
    {
        public string Data { get; }

        [JsonConstructor]
        public TestNotification(NotificationType type, string data)
            : base(type)
        {
            Data = data;
        }
    }
}
