using ArtifactsMMO.NET.Enums.ErrorCodes.Accounts;
using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Internal;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Objects.Account;
using ArtifactsMMO.NET.Objects.Achievements;
using ArtifactsMMO.NET.Queries;
using ArtifactsMMO.NET.Requests;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ArtifactsMMO.NET.Endpoints.Accounts
{
    /// <summary>
    /// Provides methods for creating accounts.
    /// </summary>
    public class ArtifactsMMOAccountsClient : ArtifactsMMOEndpoint, IArtifactsMMOAccountsClient
    {
        /// <summary>
        /// Initializes new instance of <see cref="ArtifactsMMOAccountsClient"/>
        /// </summary>
        /// <param name="httpClient"></param>
        public ArtifactsMMOAccountsClient(HttpClient httpClient) : base(httpClient)
        {
        }

        internal ArtifactsMMOAccountsClient(
            HttpClient httpClient,
            string apiKey,
            IJsonSerializerOptionsFactory jsonSerializerOptionsFactory)
            : base(httpClient, apiKey, jsonSerializerOptionsFactory)
        {
        }

        /// <summary>
        /// Create an account.
        /// </summary>
        /// <param name="createAccountRequest">The request <see cref="CreateAccountRequest"/> containing account details.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains an optional <see cref="CreateAccountError"/> that indicates any error that occurred during account creation.</returns>
        /// <exception cref="ApiException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<CreateAccountError?> CreateAccountAsync(CreateAccountRequest createAccountRequest, CancellationToken cancellationToken = default)
        {
            if (createAccountRequest == null)
            {
                throw new ArgumentNullException(nameof(createAccountRequest));
            }

            var (_, error) = await PostAsync<string, CreateAccountError>("accounts/create", createAccountRequest, cancellationToken).ConfigureAwait(false);
            return error;
        }


        /// <summary>
        /// Retrieves the details of a specific account.
        /// </summary>
        /// <param name="account">The account name.</param>
        /// <param name="cancellationToken">A token to cancel the operation (optional, defaults to <see cref="CancellationToken.None"/>).</param>
        /// <returns>
        /// A tuple containing the account details and an optional error:
        /// <list type="bullet">
        ///     <item><description><see cref="AccountDetails"/>: The details of the account, if successfully retrieved.</description></item>
        ///     <item><description><see cref="GetAccountError"/>: An optional error object in case the request fails (null if no error occurs).</description></item>
        /// </list>
        /// </returns>
        public async Task<(AccountDetails result, GetAccountError? error)> GetAccountAsync(string account, CancellationToken cancellationToken = default)
        {
            return await GetAsync<AccountDetails, GetAccountError>($"accounts/{account}", cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves the achievements of a specific account, with optional query parameters.
        /// </summary>
        /// <param name="account">Account name</param>
        /// <param name="accountAchievementsQuery">An object containing query parameters for filtering, sorting, and pagination of achievements.</param>
        /// <param name="cancellationToken">A token to cancel the operation (optional, defaults to <see cref="CancellationToken.None"/>).</param>
        /// <returns>
        /// A tuple containing the paged response of account achievements and an optional error:
        /// <list type="bullet">
        ///     <item><description><see cref="PagedResponse{AccountAchievement}"/>: A paged response containing a list of the account's achievements.</description></item>
        ///     <item><description><see cref="GetAccountError"/>: An optional error object in case the request fails (null if no error occurs).</description></item>
        /// </list>
        /// </returns>
        public async Task<(PagedResponse<AccountAchievement> result, GetAccountError? error)> GetAccountAchievementsAsync(string account, AccountAchievementsQuery accountAchievementsQuery, CancellationToken cancellationToken = default)
        {
            return await GetAsync<AccountAchievement, GetAccountError>($"accounts/{account}/achievements", accountAchievementsQuery, cancellationToken).ConfigureAwait(false);
        }
    }
}
