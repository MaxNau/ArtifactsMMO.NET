using ArtifactsMMO.NET.Enums.ErrorCodes.Effects;
using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Objects.Effects;
using ArtifactsMMO.NET.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace ArtifactsMMO.NET.Endpoints.Effects
{
    /// <summary>
    /// Endpoint to get information about various effects in game
    /// </summary>
    public interface IEffects
    {
        /// <summary>
        /// Retrieve the details of an effect.
        /// </summary>
        /// <param name="code">The unique code of the effect to retrieve.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="Effect"/> retrieved and an optional <see cref="GetEffectError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(Effect result, GetEffectError? error)> GetAsync(string code, CancellationToken cancellationToken = default);


        /// <summary>
        /// Fetch effect details.
        /// </summary>
        /// <param name="query">The query <see cref="EffectsQuery"/> to filter effects.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a <see cref="PagedResponse{Effect}"/> with the filtered effects.</returns>
        /// <exception cref="ApiException"></exception>
        Task<PagedResponse<Effect>> GetAsync(EffectsQuery query, CancellationToken cancellationToken = default);
    }
}