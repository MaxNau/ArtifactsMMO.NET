using ArtifactsMMO.NET.Enums.ErrorCodes.Character;
using ArtifactsMMO.NET.Objects.Badges;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Queries;
using System.Threading.Tasks;
using System.Threading;
using ArtifactsMMO.NET.Exceptions;

namespace ArtifactsMMO.NET.Endpoints.Badges
{
    /// <summary>
    /// Provides methods for quering badge information.
    /// </summary>
    public interface IBadges
    {
        /// <summary>
        /// Fetch badge details.
        /// </summary>
        /// <param name="query">The query <see cref="BadgesQuery"/>.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a <see cref="PagedResponse{Badge}"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<PagedResponse<Badge>> GetAsync(BadgesQuery query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieve the details of a badge.
        /// </summary>
        /// <param name="code">The code of the badge.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="Badge"/> and an optional <see cref="GetBadgeError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(Badge result, GetBadgeError? error)> GetAsync(string code, CancellationToken cancellationToken = default);
    }
}
