using ArtifactsMMO.NET.Internal;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Queries;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using ArtifactsMMO.NET.Objects.Npcs;
using ArtifactsMMO.NET.Enums.ErrorCodes.Npcs;

namespace ArtifactsMMO.NET.Endpoints.Npcs
{
    internal class Npcs : ArtifactsMMOEndpoint, INpcs
    {
        private static readonly string _resource = "npcs";

        public Npcs(HttpClient httpClient, string apiKey)
            : base(httpClient, apiKey)
        {
        }

        public Npcs(
            HttpClient httpClient,
            string apiKey,
            IJsonSerializerOptionsFactory jsonSerializerOptionsFactory)
            : base(httpClient, apiKey, jsonSerializerOptionsFactory)
        {
        }

        public async Task<PagedResponse<Npc>> GetAsync(NpcsQuery query, CancellationToken cancellationToken = default)
        {
            return await GetAsync<Npc>(_resource, query, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(Npc result, GetNpcError? error)> GetAsync(string code, CancellationToken cancellationToken = default)
        {
            return await GetAsync<Npc, GetNpcError>($"{_resource}/{code}", cancellationToken).ConfigureAwait(false);
        }

        public async Task<(PagedResponse<NpcItem> result, GetNpcError? error)> GetNpcItemsAsync(string code, CancellationToken cancellationToken = default)
        {
            return await GetAsync<NpcItem, GetNpcError>($"{_resource}/{code}/items", null, cancellationToken).ConfigureAwait(false);
        }
    }
}
