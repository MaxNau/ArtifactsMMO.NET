using ArtifactsMMO.NET.Enums.ErrorCodes.MyAccount;
using ArtifactsMMO.NET.Internal;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Objects.GrandExchange;
using ArtifactsMMO.NET.Objects.Items;
using ArtifactsMMO.NET.Objects.MyAccount;
using ArtifactsMMO.NET.Queries;
using ArtifactsMMO.NET.Requests;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ArtifactsMMO.NET.Endpoints.MyAccount
{
    internal class MyAccount : ArtifactsMMOEndpoint, IMyAccount
    {
        public MyAccount(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
        }

        internal MyAccount(HttpClient httpClient, string apiKey,
            IJsonSerializerOptionsFactory jsonSerializerOptionsFactory)
            : base(httpClient, apiKey, jsonSerializerOptionsFactory)
        {
        }

        public async Task<Bank> GetBankDetailsAsync(CancellationToken cancellationToken = default)
        {
            return await GetAsync<Bank>("my/bank", cancellationToken).ConfigureAwait(false);
        }

        public async Task<PagedResponse<SimpleItem>> GetBankItemsAsync(BankItemsQuery bankItemsQuery, CancellationToken cancellationToken = default)
        {
            return await GetAsync<SimpleItem>("my/bank/items", bankItemsQuery, cancellationToken).ConfigureAwait(false);
        }

        public async Task<MyAccountDetails> GetAccountDetailsAsync(CancellationToken cancellationToken = default)
        {
            return await GetAsync<MyAccountDetails>("my/details", cancellationToken).ConfigureAwait(false);
        }

        public async Task<PagedResponse<GrandExchangeOrder>> GetGrandExchangeSellOrdersAsync(MyGrandExchangeSellOrdersQuery grandExchangeSellOrdersQuery, CancellationToken cancellationToken = default)
        {
            return await GetAsync<GrandExchangeOrder>("my/grandexchange/orders", grandExchangeSellOrdersQuery, cancellationToken).ConfigureAwait(false);
        }

        public async Task<PagedResponse<GrandExchangeOrderHistory>> GetGrandExchangeSellHistoryAsync(MyGrandExchangeOrderHistoryQuery grandExchangeOrderHistoryQuery, CancellationToken cancellationToken = default)
        {
            return await GetAsync<GrandExchangeOrderHistory>("my/grandexchange/history", grandExchangeOrderHistoryQuery, cancellationToken).ConfigureAwait(false);
        }

        public async Task<ChangePasswordError?> ChangePasswordAsync(ChangePasswordRequest changePasswordRequest, CancellationToken cancellationToken = default)
        {
            if (changePasswordRequest == null)
            {
                throw new ArgumentNullException(nameof(changePasswordRequest));
            }

            var (_, error) = await PostAsync<string, ChangePasswordError>("my/change_password", changePasswordRequest, cancellationToken).ConfigureAwait(false);
            return error;
        }
    }
}
