﻿using ArtifactsMMO.NET.Enums.ErrorCodes.Character;
using ArtifactsMMO.NET.Objects.Achievements;
using ArtifactsMMO.NET.Objects.Characters;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Queries;
using ArtifactsMMO.NET.Requests;
using System.Threading.Tasks;
using System.Threading;
using ArtifactsMMO.NET.Exceptions;

namespace ArtifactsMMO.NET.Endpoints.Characters
{
    /// <summary>
    /// Provides methods for character management.
    /// </summary>
    public interface ICharacters
    {
        /// <summary>
        /// Create new character on your account.
        /// </summary>
        /// <remarks>
        /// You can create up to 5 characters.
        /// </remarks>
        /// <param name="createCharacterRequest">The request <see cref="CreateCharacterRequest"/> containing details for the new character.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="Character"/> created and an optional <see cref="CreateCharacterError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(Character result, CreateCharacterError? error)> CreateAsync(CreateCharacterRequest createCharacterRequest, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete character on your account.
        /// </summary>
        /// <param name="deleteCharacterRequest">The request <see cref="DeleteCharacterRequest"/> containing details of the character to be deleted.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="Character"/> that was deleted and an optional <see cref="DeleteCharacterError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(Character result, DeleteCharacterError? error)> DeleteAsync(DeleteCharacterRequest deleteCharacterRequest, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieve the details of a character.
        /// </summary>
        /// <param name="name">The name of the character to retrieve.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="Character"/> and an optional <see cref="GetCharacterError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(Character result, GetCharacterError? error)> GetAsync(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Fetch characters details.
        /// </summary>
        /// <param name="charactersQuery">The query <see cref="CharactersQuery"/> to filter characters.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a <see cref="PagedResponse{Character}"/> containing the filtered characters.</returns>
        /// <exception cref="ApiException"></exception>
        Task<PagedResponse<Character>> GetAsync(CharactersQuery charactersQuery, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieve character achievements.
        /// </summary>
        /// <param name="name">The name of the character whose achievements are to be retrieved.</param>
        /// <param name="characterAchievementsQuery">The query <see cref="CharacterAchievementsQuery"/> to filter achievements.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with a <see cref="PagedResponse{Achievement}"/> of achievements and an optional <see cref="GetCharacterAchievementsError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(PagedResponse<Achievement> result, GetCharacterAchievementsError? error)> GetAchievementAsync(string name, CharacterAchievementsQuery characterAchievementsQuery, CancellationToken cancellationToken = default);
    }
}
