using ArtifactsMMO.NET.Enums;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace ArtifactsMMO.NET.Endpoints.Assets
{
    /// <summary>
    /// Interface for a client that interacts with ArtifactMMO assets.
    /// </summary>
    public interface IArtifactsMMOAssetsClient
    {
        /// <summary>
        /// Retrieves an asset as a stream based on its type and code.
        /// </summary>
        /// <param name="assetType">The type of the asset to retrieve.</param>
        /// <param name="assetCode">The unique code identifying the asset.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation (optional).</param>
        /// <returns>A task that represents the asynchronous operation, with a stream containing the asset data.</returns>
        Task<Stream> GetAssetAsync(AssetType assetType, string assetCode, CancellationToken cancellationToken = default);
    }

}
