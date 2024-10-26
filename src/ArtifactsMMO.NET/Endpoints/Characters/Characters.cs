using ArtifactsMMO.NET.Enums.ErrorCodes.Character;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Objects.Achievements;
using ArtifactsMMO.NET.Objects.Characters;
using ArtifactsMMO.NET.Queries;
using ArtifactsMMO.NET.Requests;
using ArtifactsMMO.NET.Validators;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ArtifactsMMO.NET.Endpoints.Characters
{
    internal class Characters : ArtifactsMMOEndpoint, ICharacters
    {
        private readonly IValidator<string> _nameValidator = new CharacterNameValidator();
        public Characters(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
        }

        public async Task<(Character result, CreateCharacterError? error)> CreateAsync(CreateCharacterRequest createCharacterRequest, CancellationToken cancellationToken = default)
        {
            return await PostAsync<Character, CreateCharacterError>("characters/create", createCharacterRequest, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(Character result, DeleteCharacterError? error)> DeleteAsync(DeleteCharacterRequest deleteCharacterRequest, CancellationToken cancellationToken = default)
        {
            return await PostAsync<Character, DeleteCharacterError>("characters/delete", deleteCharacterRequest, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(Character result, GetCharacterError? error)> GetAsync(string name, CancellationToken cancellationToken = default)
        {
            _nameValidator.Validate(name);
            return await GetAsync<Character, GetCharacterError>($"characters/{name}", cancellationToken).ConfigureAwait(false);
        }

        public async Task<PagedResponse<Character>> GetAsync(CharactersQuery charactersQuery, CancellationToken cancellationToken = default)
        {
            return await GetAsync<Character>("characters", charactersQuery, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(PagedResponse<Achievement> result, GetCharacterAchievementsError? error)> GetAchievementAsync(string name, CharacterAchievementsQuery characterAchievementsQuery, CancellationToken cancellationToken = default)
        {
            return await GetAsync<Achievement, GetCharacterAchievementsError>($"characters/{name}/achievements", characterAchievementsQuery, cancellationToken).ConfigureAwait(false);
        }
    }
}
