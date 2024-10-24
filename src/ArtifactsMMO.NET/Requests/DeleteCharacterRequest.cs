using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Validators;

namespace ArtifactsMMO.NET.Requests
{
    /// <summary>
    /// Request to delete character on your account
    /// </summary>
    public class DeleteCharacterRequest : IRequest
    {
        private static readonly IValidator<string> _validator = new CharacterNameValidator();

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCharacterRequest"/> class.
        /// </summary>
        /// <param name="name">The name of the character to be deleted.</param>
        /// <exception cref="CharacterNameHasDisallowedCharacters">Thrown when the character name is invalid.</exception>
        public DeleteCharacterRequest(string name)
        {
            Name = name;

            _validator.Validate(Name);
        }

        /// <summary>
        /// Character name.
        /// </summary>
        public string Name { get; }
    }
}
