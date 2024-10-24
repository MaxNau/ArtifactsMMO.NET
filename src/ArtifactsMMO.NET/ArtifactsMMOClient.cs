using ArtifactsMMO.NET.Endpoints;
using ArtifactsMMO.NET.Endpoints.Accounts;
using ArtifactsMMO.NET.Endpoints.Achievements;
using ArtifactsMMO.NET.Endpoints.Characters;
using ArtifactsMMO.NET.Endpoints.Events;
using ArtifactsMMO.NET.Endpoints.GrandExchange;
using ArtifactsMMO.NET.Endpoints.Items;
using ArtifactsMMO.NET.Endpoints.Leaderboard;
using ArtifactsMMO.NET.Endpoints.Maps;
using ArtifactsMMO.NET.Endpoints.Monsters;
using ArtifactsMMO.NET.Endpoints.MyAccount;
using ArtifactsMMO.NET.Endpoints.Resources;
using ArtifactsMMO.NET.Endpoints.Tasks;
using ArtifactsMMO.NET.Endpoints.Token;
using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Objects.Server;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ArtifactsMMO.NET
{
    /// <summary>
    /// Represents the client for interacting with the Artifacts MMO game API.
    /// </summary>
    /// <remarks>
    /// This interface provides access to various endpoints related to game functionality,
    /// such as maps, monsters, accounts, achievements, items, and more.
    /// </remarks>
    public class ArtifactsMMOClient : ArtifactsMMOEndpoint, IArtifactsMMOClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArtifactsMMOClient"/> class with the specified HTTP client and API key.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/> used for making HTTP requests to the API.</param>
        /// <param name="apiKey">The API key used for authenticating requests to the API.</param>
        public ArtifactsMMOClient(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
            Maps = new Maps(httpClient, apiKey);
            Monsters = new Monsters(httpClient, apiKey);
            Accounts = new Accounts(httpClient, apiKey);
            MyAccount = new MyAccount(httpClient, apiKey);
            Achievements = new Achievements(httpClient, apiKey);
            Items = new Items(httpClient, apiKey);
            GrandExchange = new GrandExchange(httpClient, apiKey);
            Tasks = new Tasks(httpClient, apiKey);
            Characters = new Characters(httpClient, apiKey);
            Events = new Events(httpClient, apiKey);
            Leaderboard = new Leaderboard(httpClient, apiKey);
            Resources = new Resources(httpClient, apiKey);
            Token = new Token(httpClient, apiKey);
        }

        /// <summary>
        /// Retrieves the status of the game server.
        /// </summary>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains the server status as a <see cref="ServerStatus"/>.
        /// </returns>
        /// <exception cref="ApiException">Thrown when there is an error communicating with the API.</exception>
        public async Task<ServerStatus> GetStatusAsync(CancellationToken cancellationToken = default)
        {
            var (result, error) = await Self.GetAsync<Response<ServerStatus>>(string.Empty, cancellationToken).ConfigureAwait(false);

            if (error != null)
            {
                throw new ApiException(error.StatusCode, error.ReasonPhrase, error.ContentAsString);
            }

            return result.Data;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IMaps Maps { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IMonsters Monsters { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IAccounts Accounts { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IMyAccount MyAccount { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IAchievements Achievements { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IItems Items { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IGrandExchange GrandExchange { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ITasks Tasks { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ICharacters Characters { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IEvents Events { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ILeaderboard Leaderboard { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IResources Resources { get; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IToken Token { get; }
    }
}
