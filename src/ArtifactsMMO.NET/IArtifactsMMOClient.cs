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
using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Objects.Server;
using System.Threading.Tasks;
using System.Threading;
using ArtifactsMMO.NET.Endpoints.MyCharacters;
using ArtifactsMMO.NET.Endpoints.Badges;
using ArtifactsMMO.NET.Endpoints.Notifications;
using ArtifactsMMO.NET.Endpoints.Effects;
using ArtifactsMMO.NET.Endpoints.Npcs;

namespace ArtifactsMMO.NET
{
    /// <summary>
    /// Represents the client for interacting with the Artifacts MMO game API.
    /// </summary>
    /// <remarks>
    /// This interface provides access to various endpoints related to game functionality,
    /// such as maps, monsters, accounts, achievements, items, and more.
    /// </remarks>
    public interface IArtifactsMMOClient
    {
        /// <summary>
        /// Retrieves the status of the game server.
        /// </summary>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains the server status as a <see cref="ServerStatus"/>.
        /// </returns>
        /// <exception cref="ApiException">Thrown when there is an error communicating with the API.</exception>
        Task<ServerStatus> GetStatusAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Provides access to map-related functionality.
        /// </summary>
        IMaps Maps { get; }

        /// <summary>
        /// Provides access to monster-related functionality.
        /// </summary>
        IMonsters Monsters { get; }

        /// <summary>
        /// Provides access to functionality specific to the authenticated user's account.
        /// </summary>
        IMyAccount MyAccount { get; }

        /// <summary>
        /// Provides access to achievement-related functionality.
        /// </summary>
        IAchievements Achievements { get; }

        /// <summary>
        /// Provides access to item-related functionality.
        /// </summary>
        IItems Items { get; }

        /// <summary>
        /// Provides access to Grand Exchange functionality.
        /// </summary>
        IGrandExchange GrandExchange { get; }

        /// <summary>
        /// Provides access to task-related functionality.
        /// </summary>
        ITasks Tasks { get; }

        /// <summary>
        /// Provides access to character-related functionality.
        /// </summary>
        ICharacters Characters { get; }

        /// <summary>
        /// Provides access to event-related functionality.
        /// </summary>
        IEvents Events { get; }

        /// <summary>
        /// Provides access to leaderboard-related functionality.
        /// </summary>
        ILeaderboard Leaderboard { get; }

        /// <summary>
        /// Provides access to resource-related functionality.
        /// </summary>
        IResources Resources { get; }

        /// <summary>
        /// Provides access to character actions.
        /// </summary>
        IMyCharacters MyCharacters { get; }

        /// <summary>
        /// Provides access to badge-realted functionality.
        /// </summary>
        IBadges Badges { get; }

        /// <summary>
        /// Provides access to effects-realted functionality.
        /// </summary>
        IEffects Effects { get; }

        /// <summary>
        /// Provides access to NPCs-realted functionality.
        /// </summary>
        INpcs Npcs { get; }

        /// <summary>
        /// Provide access to the real time notifications(founder and subscribers only)
        /// </summary>
        INotifications Notifications { get; set; }
    }
}
