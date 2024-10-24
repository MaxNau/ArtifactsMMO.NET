using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Validators.Static;

namespace ArtifactsMMO.NET.Validators
{
    internal class CharacterNameValidator : IValidator<string>
    {
        public void Validate(string name)
        {
            if (!AlphaNumericUnderscoreHyphenValidator.IsValid(name))
            {
                throw new CharacterNameHasDisallowedCharacters();
            }
        }
    }
}
