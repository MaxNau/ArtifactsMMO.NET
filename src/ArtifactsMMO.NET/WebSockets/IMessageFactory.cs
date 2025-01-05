using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ArtifactsMMO.NET.WebSockets
{
    internal interface IMessageFactory<T> where T : IRealTimeMessage
    {
        bool IsApplicable(string messageText);
        T Deserialize(string messageText, JsonSerializerOptions jsonSerializerOptions);
    }
}
