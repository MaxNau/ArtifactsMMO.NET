using ArtifactsMMO.NET.Enums.ErrorCodes.Accounts;
using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace ArtifactsMMO.NET.Endpoints.Accounts
{
    /// <summary>
    /// Provides methods for creating accounts.
    /// </summary>
    public interface IAccounts
    {
        /// <summary>
        /// Create an account.
        /// </summary>
        /// <param name="createAccountRequest">The request <see cref="CreateAccountRequest"/> containing account details.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains an optional <see cref="CreateAccountError"/> that indicates any error that occurred during account creation.</returns>
        /// <exception cref="ApiException"></exception>
        Task<CreateAccountError?> CreateAccountAsync(CreateAccountRequest createAccountRequest, CancellationToken cancellationToken = default);
    }

}
