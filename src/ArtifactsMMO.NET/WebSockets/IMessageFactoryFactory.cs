using System.Text.Json;

namespace ArtifactsMMO.NET.WebSockets
{
    /// <summary>
    /// Represent the factory of factory of message from websockets
    /// </summary>
    /// <typeparam name="T">The common type of message</typeparam>
    internal interface IMessageFactoryFactory<T> where T : IRealTimeMessage
    {
        /// <summary>
        /// Deserialize the provided JSON message into a specific message
        /// </summary>
        /// <param name="messageText">The JSON message</param>
        /// <param name="jsonSerializerOptions">The JSON settings</param>
        /// <returns>The deserialized message</returns>
        T Deserialize(string messageText, JsonSerializerOptions jsonSerializerOptions);
    }
}
