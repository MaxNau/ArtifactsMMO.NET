using ArtifactsMMO.NET.Enums.ErrorCodes.Npcs;
using ArtifactsMMO.NET.Objects.Npcs;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Queries;
using System.Threading.Tasks;
using System.Threading;
using ArtifactsMMO.NET.Exceptions;

namespace ArtifactsMMO.NET.Endpoints.Npcs
{
    /// <summary>
    /// Provides methods for retrieving NPC-related information.
    /// </summary>
    public interface INpcs
    {
        /// <summary>
        /// Fetch NPCs details.
        /// </summary>
        /// <param name="query">The query <see cref="NpcsQuery"/> to filter NPCs.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a <see cref="PagedResponse{Npc}"/> with the filtered resources.</returns>
        /// <exception cref="ApiException"></exception>
        Task<PagedResponse<Npc>> GetAsync(NpcsQuery query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieve the details of then NPC.
        /// </summary>
        /// <param name="code">The unique code of the NPC to retrieve.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="Npc"/> retrieved and an optional <see cref="GetNpcError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(Npc result, GetNpcError? error)> GetAsync(string code, CancellationToken cancellationToken = default);

        /// <summary>
        /// Fetch NPC item details.
        /// </summary>
        /// <param name="code">The unique code of the NPC.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a <see cref="PagedResponse{NpcItem}"/> with the filtered resources.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(PagedResponse<NpcItem> result, GetNpcError? error)> GetNpcItemsAsync(string code, CancellationToken cancellationToken = default);
    }
}
