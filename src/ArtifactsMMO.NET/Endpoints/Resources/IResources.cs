using ArtifactsMMO.NET.Objects.Resources;
using System.Threading.Tasks;
using System.Threading;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Queries;
using ArtifactsMMO.NET.Enums.ErrorCodes.Resources;
using ArtifactsMMO.NET.Exceptions;

namespace ArtifactsMMO.NET.Endpoints.Resources
{
    /// <summary>
    /// Provides methods for retrieving resource-related information.
    /// </summary>
    public interface IResources
    {
        /// <summary>
        /// Retrieve the details of a resource.
        /// </summary>
        /// <param name="code">The unique code of the resource to retrieve.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="Resource"/> retrieved and an optional <see cref="GetResourceError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(Resource result, GetResourceError? error)> GetAsync(string code, CancellationToken cancellationToken = default);

        /// <summary>
        /// Fetch resources details.
        /// </summary>
        /// <param name="resourceQuery">The query <see cref="ResourcesQuery"/> to filter resources.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a <see cref="PagedResponse{Resource}"/> with the filtered resources.</returns>
        /// <exception cref="ApiException"></exception>
        Task<PagedResponse<Resource>> GetAsync(ResourcesQuery resourceQuery, CancellationToken cancellationToken = default);
    }
}
