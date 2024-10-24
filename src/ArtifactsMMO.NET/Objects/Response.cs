using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects
{
    internal class Response<T>
    {
        [JsonConstructor]
        internal Response(T data)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
