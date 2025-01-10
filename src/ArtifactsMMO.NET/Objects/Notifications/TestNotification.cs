using System.Text.Json.Serialization;

using ArtifactsMMO.NET.Enums;

namespace ArtifactsMMO.NET.Objects.Notifications
{
    /// <summary>
    /// Test notification from the server
    /// This get emitted every 60 seconds, for test purpose
    /// </summary>
    public class TestNotification : ServerNotification
    {
        /// <summary>
        /// Test message from the server
        /// </summary>
        public string Data { get; }

        /// <summary>
        /// Create a new test notification
        /// </summary>
        /// <param name="type">The notification type</param>
        /// <param name="data">The test message</param>
        [JsonConstructor]
        public TestNotification(NotificationType type, string data)
            : base(type)
        {
            Data = data;
        }
    }
}
