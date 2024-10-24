using ArtifactsMMO.NET.Objects.Maps;
using System.Threading.Tasks;
using System.Threading;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Queries;
using ArtifactsMMO.NET.Enums.ErrorCodes.Character;
using ArtifactsMMO.NET.Exceptions;

namespace ArtifactsMMO.NET.Endpoints.Maps
{
    /// <summary>
    /// Provides methods for retrieving map-related information.
    /// </summary>
    public interface IMaps
    {
        /// <summary>
        /// Retrieve the details of a map.
        /// </summary>
        /// <param name="x">The X coordinate of the map.</param>
        /// <param name="y">The Y coordinate of the map.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="Map"/> retrieved and an optional <see cref="GetMapError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(Map result, GetMapError? error)> GetAsync(int x, int y, CancellationToken cancellationToken = default);

        /// <summary>
        /// Fetch maps details.
        /// </summary>
        /// <param name="mapsQuery">The query <see cref="MapsQuery"/> to filter maps.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a <see cref="PagedResponse{Map}"/> with the filtered maps.</returns>
        /// <exception cref="ApiException"></exception>
        Task<PagedResponse<Map>> GetAsync(MapsQuery mapsQuery,
            CancellationToken cancellationToken = default);
    }
}
