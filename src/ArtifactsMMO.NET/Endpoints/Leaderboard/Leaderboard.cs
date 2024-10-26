using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Objects.Leaderboard;
using ArtifactsMMO.NET.Queries;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ArtifactsMMO.NET.Endpoints.Leaderboard
{
    internal class Leaderboard : ArtifactsMMOEndpoint, ILeaderboard
    {
        private readonly string _resource = "leaderboard";
        public Leaderboard(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
        }

        public async Task<PagedResponse<CharacterLeaderboard>> GetAsync(LeaderboardQuery leaderboardQuery,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<CharacterLeaderboard>(_resource, leaderboardQuery, cancellationToken).ConfigureAwait(false);
        }
    }
}
