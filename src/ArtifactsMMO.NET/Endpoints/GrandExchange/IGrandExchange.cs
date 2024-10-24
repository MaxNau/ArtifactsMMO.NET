using ArtifactsMMO.NET.Objects.GrandExchange;
using System.Threading.Tasks;
using System.Threading;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Queries;
using ArtifactsMMO.NET.Enums.ErrorCodes.GrandExchange;
using ArtifactsMMO.NET.Exceptions;

namespace ArtifactsMMO.NET.Endpoints.GrandExchange
{
    /// <summary>
    /// Provides methods for retrieving Grand Exchange item-related information.
    /// </summary>
    public interface IGrandExchange
    {
        /// <summary>
        /// Retrieve the details of a Grand Exchange item.
        /// </summary>
        /// <param name="code">The unique code of the Grand Exchange item to retrieve.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="GrandExchangeItem"/> retrieved and an optional <see cref="GetGeItemError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(GrandExchangeItem result, GetGeItemError? error)> GetAsync(string code, CancellationToken cancellationToken = default);

        /// <summary>
        /// Fetch Grand Exchange items details.
        /// </summary>
        /// <param name="grandExchangeQuery">The query <see cref="GrandExchangeQuery"/> to filter Grand Exchange items.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a <see cref="PagedResponse{GrandExchangeItem}"/> with the filtered Grand Exchange items.</returns>
        /// <exception cref="ApiException"></exception>
        Task<PagedResponse<GrandExchangeItem>> GetAsync(GrandExchangeQuery grandExchangeQuery, CancellationToken cancellationToken = default);
    }
}
