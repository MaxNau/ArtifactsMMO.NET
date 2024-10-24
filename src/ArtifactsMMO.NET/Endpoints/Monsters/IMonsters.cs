using ArtifactsMMO.NET.Objects.Monsters;
using ArtifactsMMO.NET.Objects;
using System.Threading.Tasks;
using System.Threading;
using ArtifactsMMO.NET.Queries;
using ArtifactsMMO.NET.Enums.ErrorCodes.Monsters;
using ArtifactsMMO.NET.Exceptions;

namespace ArtifactsMMO.NET.Endpoints.Monsters
{
    /// <summary>
    /// Provides methods for retrieving monster-related information.
    /// </summary>
    public interface IMonsters
    {
        /// <summary>
        /// Retrieve the details of a monster.
        /// </summary>
        /// <param name="code">The unique code of the monster to retrieve.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="Monster"/> retrieved and an optional <see cref="GetMonsterError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(Monster result, GetMonsterError? error)> GetAsync(string code, CancellationToken cancellationToken = default);

        /// <summary>
        /// Fetch monsters details.
        /// </summary>
        /// <param name="monstersQuery">The query <see cref="MonstersQuery"/> to filter monsters.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a <see cref="PagedResponse{Monster}"/> with the filtered monsters.</returns>
        /// <exception cref="ApiException"></exception>
        Task<PagedResponse<Monster>> GetAsync(MonstersQuery monstersQuery, CancellationToken cancellationToken = default);
    }
}
