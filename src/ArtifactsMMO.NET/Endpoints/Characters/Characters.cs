﻿using ArtifactsMMO.NET.Enums.ErrorCodes.Character;
using ArtifactsMMO.NET.Internal;
using ArtifactsMMO.NET.Objects.Characters;
using ArtifactsMMO.NET.Requests;
using ArtifactsMMO.NET.Validators;
using System;
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

        internal Characters(HttpClient httpClient, string apiKey,
            IJsonSerializerOptionsFactory jsonSerializerOptionsFactory)
            : base(httpClient, apiKey, jsonSerializerOptionsFactory)
        {
        }

        public async Task<(Character result, CreateCharacterError? error)> CreateAsync(CreateCharacterRequest createCharacterRequest, CancellationToken cancellationToken = default)
        {
            if (createCharacterRequest == null)
            {
                throw new ArgumentNullException(nameof(createCharacterRequest));
            }   
            
            return await PostAsync<Character, CreateCharacterError>("characters/create", createCharacterRequest, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(Character result, DeleteCharacterError? error)> DeleteAsync(DeleteCharacterRequest deleteCharacterRequest, CancellationToken cancellationToken = default)
        {
            if (deleteCharacterRequest == null)
            {
                throw new ArgumentNullException(nameof(deleteCharacterRequest));
            }

            return await PostAsync<Character, DeleteCharacterError>("characters/delete", deleteCharacterRequest, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(Character result, GetCharacterError? error)> GetAsync(string name, CancellationToken cancellationToken = default)
        {
            _nameValidator.Validate(name);
            return await GetAsync<Character, GetCharacterError>($"characters/{name}", cancellationToken).ConfigureAwait(false);
        }
    }
}
