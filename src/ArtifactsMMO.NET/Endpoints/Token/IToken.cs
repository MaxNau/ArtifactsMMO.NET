using System.Threading.Tasks;
using System.Threading;
using ArtifactsMMO.NET.Enums.ErrorCodes.Token;
using ArtifactsMMO.NET.Exceptions;

namespace ArtifactsMMO.NET.Endpoints.Token
{
    /// <summary>
    /// Provides methods for managing authentication tokens.
    /// </summary>
    public interface IToken
    {
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
        Task<(string token, GenerateTokenError? error)> GenerateTokenAsync(string username, string password, CancellationToken cancellationToken = default);
    }
}
