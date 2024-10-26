using ArtifactsMMO.NET.Enums.ErrorCodes.Token;
using ArtifactsMMO.NET.Errors;
using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Objects;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArtifactsMMO.NET.Endpoints.Token
{
    /// <summary>
    /// Provides methods for managing authentication tokens.
    /// </summary>
    public class ArtifactsMMOTokenClient : ArtifactsMMOEndpoint, IArtifactsMMOTokenClient
    {
        private readonly ArtifactsMMOApiErrorFactory _errorFactory;

        /// <summary>
        /// Initializes new instance of <see cref="ArtifactsMMOTokenClient"/>
        /// </summary>
        /// <param name="httpClient"></param>
        public ArtifactsMMOTokenClient(HttpClient httpClient) : base(httpClient)
        {
            _errorFactory = new ArtifactsMMOApiErrorFactory();
        }

        /// <summary>
        /// Use your account as HTTPBasic Auth to generate your token to use the API.
        /// You can also generate your token directly on the website.
        /// </summary>
        /// <param name="username">The username of the user for whom the token is being generated.</param>
        /// <param name="password">The password of the user for authentication.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the generated token as a <see cref="string"/> and an optional <see cref="GenerateTokenError"/> indicating any error that occurred during token generation.</returns>
        /// <exception cref="ApiException"></exception>
        public async Task<(string token, GenerateTokenError? error)> GenerateTokenAsync(string username, string password, CancellationToken cancellationToken = default)
        {
            var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            var headers = new Dictionary<string, string> { { "Authorization", $"Basic {base64Credentials}" } };
            var (result, error) = await Self.PostAsync<ApiToken>("token", headers, cancellationToken).ConfigureAwait(false);
            var errorCode = _errorFactory.Get<GenerateTokenError>(error);
            return (result?.Token, errorCode);
        }
    }
}
