using ArtifactsMMO.NET.Objects.Items;
using ArtifactsMMO.NET.Objects.MyAccount;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Queries;
using System.Threading.Tasks;
using System.Threading;
using ArtifactsMMO.NET.Enums.ErrorCodes.MyAccount;
using ArtifactsMMO.NET.Exceptions;

namespace ArtifactsMMO.NET.Endpoints.MyAccount
{
    /// <summary>
    /// Provides methods for managing your account.
    /// </summary>
    public interface IMyAccount
    {
        /// <summary>
        /// Fetch bank details.
        /// </summary>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation, containing the <see cref="Bank"/> details.</returns>
        /// <exception cref="ApiException"></exception>
        Task<Bank> GetBankDetailsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Fetch all items in your bank.
        /// </summary>
        /// <param name="bankItemsQuery">The query <see cref="BankItemsQuery"/> specifying the criteria for fetching bank items.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation, containing a paged response of <see cref="SimpleItem"/> instances.</returns>
        /// <exception cref="ApiException"></exception>
        Task<PagedResponse<SimpleItem>> GetBankItemsAsync(BankItemsQuery bankItemsQuery, CancellationToken cancellationToken = default);

        /// <summary>
        /// Change your account password. Changing the password reset the account token.
        /// </summary>
        /// <param name="password">The new password to set for the account.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation, containing an optional <see cref="ChangePasswordError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<ChangePasswordError?> ChangePasswordAsync(string password, CancellationToken cancellationToken = default);
    }
}
