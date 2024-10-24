using ArtifactsMMO.NET.Enums.ErrorCodes.Token;
using ArtifactsMMO.NET.Errors;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArtifactsMMO.NET.Endpoints.Token
{
    internal class Token : ArtifactsMMOEndpoint, IToken
    {
        private readonly ArtifactsMMOApiErrorFactory _errorFactory;
        public Token(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
            _errorFactory = new ArtifactsMMOApiErrorFactory();
        }

        public async Task<(string token, GenerateTokenError? error)> GenerateTokenAsync(string username, string password, CancellationToken cancellationToken = default)
        {
            var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            var headers = new Dictionary<string, string> { { "Authorization", $"Basic {base64Credentials}" } };
            var (result, error) = await Self.PostAsync<string>("token", headers, cancellationToken).ConfigureAwait(false);
            var errorCode = _errorFactory.Get<GenerateTokenError>(error);
            return (result, errorCode);
        }
    }
}
