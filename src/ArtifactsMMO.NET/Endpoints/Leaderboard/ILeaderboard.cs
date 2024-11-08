using ArtifactsMMO.NET.Objects.Leaderboard;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Queries;
using System.Threading.Tasks;
using System.Threading;
using ArtifactsMMO.NET.Exceptions;

namespace ArtifactsMMO.NET.Endpoints.Leaderboard
{
    /// <summary>
    /// Provides methods for retrieving leaderboard-related information.
    /// </summary>
    public interface ILeaderboard
    {
        /// <summary>
        /// Fetch characters leaderboard details.
        /// </summary>
        /// <param name="leaderboardQuery">The query <see cref="CharactersLeaderboardQuery"/> to filter the leaderboard results.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a <see cref="PagedResponse{CharacterLeaderboard}"/> with the leaderboard data.</returns>
        /// <exception cref="ApiException"></exception>
        Task<PagedResponse<CharacterLeaderboard>> GetAsync(CharactersLeaderboardQuery leaderboardQuery, CancellationToken cancellationToken = default);


        /// <summary>
        /// Fetch accounts leaderboard details.
        /// </summary>
        /// <param name="leaderboardQuery">The query <see cref="AccountsLeaderboardQuery"/> to filter the leaderboard results.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a <see cref="PagedResponse{AccountLeaderboard}"/> with the leaderboard data.</returns>
        /// <exception cref="ApiException"></exception>
        Task<PagedResponse<AccountLeaderboard>> GetAsync(AccountsLeaderboardQuery leaderboardQuery,
            CancellationToken cancellationToken = default);
    }
}
