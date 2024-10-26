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
        private readonly string _resource = "events";

        public Events(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
        }

        public async Task<PagedResponse<Event>> GetAsync(EventsQuery eventsQuery,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<Event>(_resource, eventsQuery, cancellationToken).ConfigureAwait(false);
        }
    }
}
