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
    /// Provides methods for retrieving Grand Exchange sell order related information.
    /// </summary>
    public interface IGrandExchange
    {
        /// <summary>
        /// Fetch the sales history of the item for the last 7 days.
        /// </summary>
        /// <param name="itemCode">The code of the Grand Exchange item to retrieve history for.</param>
        /// <param name="grandExchangeSellHistoryQuery">The query <see cref="GrandExchangeSellHistoryQuery"/> to filter Grand Exchange order history.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a <see cref="PagedResponse{GrandExchangeOrderHistory}"/> with the filtered Grand Exchange order history.</returns>
        /// <exception cref="ApiException"></exception>
        Task<PagedResponse<GrandExchangeOrderHistory>> GetSellHistoryAsync(string itemCode, GrandExchangeSellHistoryQuery grandExchangeSellHistoryQuery,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Fetch all sell orders.
        /// </summary>
        /// <param name="grandExchangeSellOrdersQuery">The query <see cref="GrandExchangeSellOrdersQuery"/> to filter Grand Exchange orders.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a <see cref="PagedResponse{GrandExchangeOrder}"/> with the filtered Grand Exchange orders.</returns>
        /// <exception cref="ApiException"></exception>
        Task<PagedResponse<GrandExchangeOrder>> GetSellOrdersAsync(GrandExchangeSellOrdersQuery grandExchangeSellOrdersQuery,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Fetch Grand Exchange order details.
        /// </summary>
        /// <param name="id">The id of the order.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="GrandExchangeOrder"/>
        /// and an optional <see cref="GetGrandExchangeSellOrderError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(GrandExchangeOrder result, GetGrandExchangeSellOrderError? error)> GetOrderAsync(string id, CancellationToken cancellationToken);
    }
}
