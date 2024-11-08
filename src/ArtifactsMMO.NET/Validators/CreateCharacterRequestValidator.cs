using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Requests;
using ArtifactsMMO.NET.Validators.Static;
using System;

namespace ArtifactsMMO.NET.Validators
{
    internal class CreateCharacterRequestValidator : IValidator<CreateCharacterRequest>
    {
        public void Validate(CreateCharacterRequest createCharacterRequest)
        {
            if (!AlphaNumericUnderscoreHyphenValidator.IsValid(createCharacterRequest.Name))
            {
                throw new CharacterNameHasDisallowedCharacters();
            }

            if (createCharacterRequest.Name.Length < 3 || createCharacterRequest.Name.Length > 12)
            {
                throw new ArgumentException("Character name must be between 3 and 12 characters long.");
            }
        }
    }
}
