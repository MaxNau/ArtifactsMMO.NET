using ArtifactsMMO.NET.Internal;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Objects.Events;
using ArtifactsMMO.NET.Queries;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ArtifactsMMO.NET.Endpoints.Events
{
    internal class Events : ArtifactsMMOEndpoint, IEvents
    {
        public Events(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
        }

        internal Events(HttpClient httpClient, string apiKey,
            IJsonSerializerOptionsFactory jsonSerializerOptionsFactory)
            : base(httpClient, apiKey, jsonSerializerOptionsFactory)
        {
        }

        public async Task<PagedResponse<Event>> GetAllAsync(EventsQuery eventsQuery,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<Event>("events", eventsQuery, cancellationToken).ConfigureAwait(false);
        }


        public async Task<PagedResponse<ActiveEvent>> GetActiveAsync(EventsQuery eventsQuery,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<ActiveEvent>("events/active", eventsQuery, cancellationToken).ConfigureAwait(false);
        }
    }
}
