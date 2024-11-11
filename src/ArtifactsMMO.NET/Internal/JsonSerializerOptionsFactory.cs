using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Internal
{
    internal class JsonSerializerOptionsFactory : IJsonSerializerOptionsFactory
    {
        public JsonSerializerOptions Get(JsonSerializerOptionsMode mode)
        {
            var options = GetBaseOptions();

            switch (mode)
            {
                case JsonSerializerOptionsMode.Default:
                    return options;
                case JsonSerializerOptionsMode.Test:
                    options.UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow;
                    return options;
                default:
                    throw new NotImplementedException($"Unsupported mode: {mode}");
            }
        }

        private JsonSerializerOptions GetBaseOptions()
        {
            return new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Converters =
            {
                new JsonStringEnumConverter(JsonNamingPolicy.SnakeCaseLower)
            }
            };
        }
    }
}
