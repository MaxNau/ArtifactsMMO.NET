using System.Text.Json;

namespace ArtifactsMMO.NET.WebSockets
{
    internal interface IMessageFactoryFactory<T> where T : IRealTimeMessage
    {
        T Deserialize(string messageText, JsonSerializerOptions jsonSerializerOptions);
    }
}
