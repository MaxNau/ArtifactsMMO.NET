using ArtifactsMMO.NET.Enums.ErrorCodes.Character;
using ArtifactsMMO.NET.Objects.Characters;
using ArtifactsMMO.NET.Requests;
using System.Threading.Tasks;
using System.Threading;
using ArtifactsMMO.NET.Exceptions;
using System;

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
        /// <exception cref="ArgumentNullException"></exception>
        Task<(Character result, CreateCharacterError? error)> CreateAsync(CreateCharacterRequest createCharacterRequest, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete character on your account.
        /// </summary>
        /// <param name="deleteCharacterRequest">The request <see cref="DeleteCharacterRequest"/> containing details of the character to be deleted.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="Character"/> that was deleted and an optional <see cref="DeleteCharacterError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
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
    }
}
