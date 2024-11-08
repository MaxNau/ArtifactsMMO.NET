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
        public Leaderboard(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
        }

        public async Task<PagedResponse<CharacterLeaderboard>> GetAsync(CharactersLeaderboardQuery leaderboardQuery,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<CharacterLeaderboard>("leaderboard/characters", leaderboardQuery, cancellationToken).ConfigureAwait(false);
        }

        public async Task<PagedResponse<AccountLeaderboard>> GetAsync(AccountsLeaderboardQuery leaderboardQuery,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<AccountLeaderboard>("leaderboard/accounts", leaderboardQuery, cancellationToken).ConfigureAwait(false);
        }
    }
}
