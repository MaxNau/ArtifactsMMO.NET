using ArtifactsMMO.NET.Enums.ErrorCodes.GrandExchange;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Objects.GrandExchange;
using ArtifactsMMO.NET.Queries;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ArtifactsMMO.NET.Endpoints.GrandExchange
{
    internal class GrandExchange : ArtifactsMMOEndpoint, IGrandExchange
    {
        public GrandExchange(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
        }

        public async Task<PagedResponse<GrandExchangeOrderHistory>> GetSellHistoryAsync(string itemCode, GrandExchangeSellHistoryQuery grandExchangeSellHistoryQuery,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<GrandExchangeOrderHistory>($"grandexchange/history/{itemCode}", grandExchangeSellHistoryQuery, cancellationToken).ConfigureAwait(false);
        }

        public async Task<PagedResponse<GrandExchangeOrder>> GetSellOrdersAsync(GrandExchangeSellOrdersQuery grandExchangeSellOrdersQuery,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<GrandExchangeOrder>("grandexchange/orders", grandExchangeSellOrdersQuery, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(GrandExchangeOrder result, GetGrandExchangeSellOrderError? error)> GetOrderAsync(string id, CancellationToken cancellationToken)
        {
            return await GetAsync<GrandExchangeOrder, GetGrandExchangeSellOrderError>($"grandexchange/orders/{id}", cancellationToken).ConfigureAwait(false);
        }
    }
}
