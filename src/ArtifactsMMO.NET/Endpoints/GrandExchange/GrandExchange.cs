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
        private readonly string _resource = "ge";
        public GrandExchange(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
        }

        public async Task<(GrandExchangeItem result, GetGeItemError? error)> GetAsync(string code, CancellationToken cancellationToken = default)
        {
            return await GetAsync<GrandExchangeItem, GetGeItemError>($"{_resource}/{code}", cancellationToken).ConfigureAwait(false);
        }

        public async Task<PagedResponse<GrandExchangeItem>> GetAsync(GrandExchangeQuery grandExchangeQuery,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<GrandExchangeItem>(_resource, grandExchangeQuery, cancellationToken).ConfigureAwait(false);
        }
    }
}
