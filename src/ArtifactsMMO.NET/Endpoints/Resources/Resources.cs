using ArtifactsMMO.NET.Enums.ErrorCodes.Resources;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Objects.Resources;
using ArtifactsMMO.NET.Queries;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ArtifactsMMO.NET.Endpoints.Resources
{
    internal class Resources : ArtifactsMMOEndpoint, IResources
    {
        private readonly string _resource = "resources";
        public Resources(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
        }

        public async Task<(Resource result, GetResourceError? error)> GetAsync(string code, CancellationToken cancellationToken = default)
        {
            return await GetAsync<Resource, GetResourceError>($"{_resource}/{code}", cancellationToken).ConfigureAwait(false);
        }

        public async Task<PagedResponse<Resource>> GetAsync(ResourcesQuery resourcesQuery,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<Resource>(_resource, resourcesQuery, cancellationToken).ConfigureAwait(false);
        }
    }
}
