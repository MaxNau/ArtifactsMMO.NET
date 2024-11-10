using System.Text.Json;

namespace ArtifactsMMO.NET.Internal
{
    internal interface IJsonSerializerOptionsFactory
    {
        JsonSerializerOptions Get(JsonSerializerOptionsMode mode);
    }
}
