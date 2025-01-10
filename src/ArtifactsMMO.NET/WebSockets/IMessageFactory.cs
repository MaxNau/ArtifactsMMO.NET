using System.Text.Json;

namespace ArtifactsMMO.NET.WebSockets
{
    /// <summary>
    /// Represents factories that will be used to create the proper message type depending on the json string
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IMessageFactory<out T> where T : IRealTimeMessage
    {
        /// <summary>
        /// Method to check if the current factories can be used to deserialize the provided message
        /// </summary>
        /// <param name="messageText">The received message</param>
        /// <returns>True if it applies, false otherwise</returns>
        bool IsApplicable(string messageText);

        /// <summary>
        /// Deserialize the provided message into the proper message
        /// </summary>
        /// <param name="messageText">The message to deserialize</param>
        /// <param name="jsonSerializerOptions">The json options to use to deserialize the message</param>
        /// <returns>The deserialized message</returns>
        T Deserialize(string messageText, JsonSerializerOptions jsonSerializerOptions);
    }
}
