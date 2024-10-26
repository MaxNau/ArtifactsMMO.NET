using ArtifactsMMO.NET.Objects.Achievements;
using System.Threading.Tasks;
using System.Threading;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Queries;
using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Enums.ErrorCodes.Achievments;

namespace ArtifactsMMO.NET.Endpoints.Achievements
{
    /// <summary>
    /// Provides methods for retrieving achievement-related information.
    /// </summary>
    public interface IAchievements
    {
        /// <summary>
        /// Retrieve the details of a achievement.
        /// </summary>
        /// <param name="code">The unique code of the achievement to retrieve.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="Achievement"/> retrieved and an optional <see cref="GetAchievementError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(Achievement result, GetAchievementError? error)> GetAsync(string code, CancellationToken cancellationToken = default);

        /// <summary>
        /// List of all achievements.
        /// </summary>
        /// <param name="achievementsQuery">The query <see cref="AchievementsQuery"/> to filter achievements.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a <see cref="PagedResponse{Achievement}"/> with the filtered achievements.</returns>
        /// <exception cref="ApiException"></exception>
        Task<PagedResponse<Achievement>> GetAsync(AchievementsQuery achievementsQuery, CancellationToken cancellationToken = default);
    }

}
