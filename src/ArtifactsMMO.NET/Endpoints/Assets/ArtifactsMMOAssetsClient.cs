using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Http;
using ArtifactsMMO.NET.Internal;
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ArtifactsMMO.NET.Endpoints.Assets
{
    /// <summary>
    /// A client for interacting with MMO asset artifacts via REST API calls.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="RestClient"/> and implements <see cref="IArtifactsMMOAssetsClient"/>.
    /// It is responsible for retrieving asset data from the specified base URL.
    /// </remarks>
    public class ArtifactsMMOAssetsClient : RestClient, IArtifactsMMOAssetsClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArtifactsMMOAssetsClient"/> class.
        /// </summary>
        /// <param name="httpClient">An instance of <see cref="HttpClient"/> used for making HTTP requests.</param>
        /// <remarks>
        /// The <paramref name="httpClient"/> is configured with a base address of <c>https://artifactsmmo.com/</c>.
        /// </remarks>
        public ArtifactsMMOAssetsClient(HttpClient httpClient) : base(httpClient)
        {
            httpClient.BaseAddress = new Uri("https://artifactsmmo.com/");
            SetUserAgent();
        }

        /// <summary>
        /// Retrieves an asset as a stream based on its type and code.
        /// </summary>
        /// <param name="assetType">The type of the asset to retrieve.</param>
        /// <param name="assetCode">The unique code identifying the asset.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation (optional).</param>
        /// <returns>A task that represents the asynchronous operation, with a stream containing the asset data.</returns>
        public async Task<Stream> GetAssetAsync(AssetType assetType, string assetCode, CancellationToken cancellationToken = default)
        {
            return await Self.GetAsStreamAsync($"images/{assetType.ToString().ToLower()}/{assetCode}.png", cancellationToken).ConfigureAwait(false);
        }

        private void SetUserAgent()
        {
            AddDefaultRequestHeader("User-Agent", $"ArtifactsMMO.NET/{VersionHelper.Version}");
        }
    }
}
