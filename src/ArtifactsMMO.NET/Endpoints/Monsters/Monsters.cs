using ArtifactsMMO.NET.Enums.ErrorCodes.Monsters;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Objects.Monsters;
using ArtifactsMMO.NET.Queries;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ArtifactsMMO.NET.Endpoints.Monsters
{
    internal class Monsters : ArtifactsMMOEndpoint, IMonsters
    {
        private readonly string _resource = "monsters";
        public Monsters(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
        }

        public async Task<(Monster result, GetMonsterError? error)> GetAsync(string code, CancellationToken cancellationToken = default)
        {
            return await GetAsync<Monster, GetMonsterError>($"{_resource}/{code}", cancellationToken).ConfigureAwait(false);
        }

        public async Task<PagedResponse<Monster>> GetAsync(MonstersQuery monstersQuery,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<Monster>(_resource, monstersQuery, cancellationToken).ConfigureAwait(false);
        }
    }
}
