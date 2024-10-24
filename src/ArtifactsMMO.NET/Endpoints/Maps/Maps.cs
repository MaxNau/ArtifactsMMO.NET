using ArtifactsMMO.NET.Enums.ErrorCodes.Character;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Objects.Maps;
using ArtifactsMMO.NET.Queries;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ArtifactsMMO.NET.Endpoints.Maps
{
    internal class Maps : ArtifactsMMOEndpoint, IMaps
    {
        private readonly string _resource = "maps";

        public Maps(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
        }

        public async Task<(Map result, GetMapError? error)> GetAsync(int x, int y, CancellationToken cancellationToken = default)
        {
            return await GetAsync<Map, GetMapError>($"{_resource}/{x}/{y}", cancellationToken).ConfigureAwait(false);
        }

        public async Task<PagedResponse<Map>> GetAsync(MapsQuery mapsQuery,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<Map>(_resource, mapsQuery, cancellationToken).ConfigureAwait(false);
        }
    }
}
