using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects
{
    internal class ApiToken
    {
        internal ApiToken() { }

        [JsonConstructor]
        internal ApiToken(string token)
        {
            Token = token;
        }

        public string Token { get; }
    }
}
