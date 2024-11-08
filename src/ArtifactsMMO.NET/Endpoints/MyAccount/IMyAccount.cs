using ArtifactsMMO.NET.Objects.Items;
using ArtifactsMMO.NET.Objects.MyAccount;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Queries;
using System.Threading.Tasks;
using System.Threading;
using ArtifactsMMO.NET.Enums.ErrorCodes.MyAccount;
using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Requests;
using ArtifactsMMO.NET.Objects.GrandExchange;

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
        /// Fetch your sell orders details.
        /// </summary>
        /// <param name="grandExchangeSellOrdersQuery">The query <see cref="MyGrandExchangeSellOrdersQuery"/> specifying the criteria for fetching sell orders.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation, containing a paged response of <see cref="GrandExchangeOrder"/> instances.</returns>
        /// <exception cref="ApiException"></exception>
        Task<PagedResponse<GrandExchangeOrder>> GetGrandExchangeSellOrdersAsync(MyGrandExchangeSellOrdersQuery grandExchangeSellOrdersQuery, CancellationToken cancellationToken = default);

        /// <summary>
        /// Fetch your sales history of the last 7 days.
        /// </summary>
        /// <param name="grandExchangeOrderHistoryQuery">The query <see cref="MyGrandExchangeOrderHistoryQuery"/> specifying the criteria for fetching sell orders history.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation, containing a paged response of <see cref="GrandExchangeOrderHistory"/> instances.</returns>
        /// <exception cref="ApiException"></exception>
        Task<PagedResponse<GrandExchangeOrderHistory>> GetGrandExchangeSellHistoryAsync(MyGrandExchangeOrderHistoryQuery grandExchangeOrderHistoryQuery, CancellationToken cancellationToken = default);

        /// <summary>
        /// Fetch account details.
        /// </summary>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation, containing the <see cref="MyAccountDetails"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<MyAccountDetails> GetAccountDetailsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Change your account password. Changing the password reset the account token.
        /// </summary>
        /// <param name="changePasswordRequest">Request to set a new password. Current password must be provided as well.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation, containing an optional <see cref="ChangePasswordError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<ChangePasswordError?> ChangePasswordAsync(ChangePasswordRequest changePasswordRequest, CancellationToken cancellationToken = default);
    }
}
