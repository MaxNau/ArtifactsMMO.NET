using ArtifactsMMO.NET.Objects.Items;
using ArtifactsMMO.NET.Objects;
using System.Threading.Tasks;
using System.Threading;
using ArtifactsMMO.NET.Queries;
using ArtifactsMMO.NET.Enums.ErrorCodes.Items;
using ArtifactsMMO.NET.Exceptions;

namespace ArtifactsMMO.NET.Endpoints.Items
{
    /// <summary>
    /// Provides methods for retrieving item-related information.
    /// </summary>
    public interface IItems
    {
        /// <summary>
        /// Retrieve the details of a item.
        /// </summary>
        /// <param name="code">The unique code of the item to retrieve.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="Item"/> retrieved and an optional <see cref="GetItemError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(Item result, GetItemError? error)> GetAsync(string code, CancellationToken cancellationToken = default);

        /// <summary>
        /// Fetch items details.
        /// </summary>
        /// <param name="itemsQuery">The query <see cref="ItemsQuery"/> to filter items.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a <see cref="PagedResponse{Item}"/> with the filtered items.</returns>
        /// <exception cref="ApiException"></exception>
        Task<PagedResponse<Item>> GetAsync(ItemsQuery itemsQuery, CancellationToken cancellationToken = default);

    }
}
