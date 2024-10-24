using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Validators;
using System;

namespace ArtifactsMMO.NET.Requests
{
    /// <summary>
    /// Request to create new character on your account
    /// </summary>
    /// <remarks>
    ///  You can create up to 5 characters.
    /// </remarks>
    public class CreateCharacterRequest : IRequest
    {
        private readonly static IValidator<CreateCharacterRequest> _validator = new CreateCharacterRequestValidator();

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCharacterRequest"/> class.
        /// </summary>
        /// <param name="name">The name of the character.</param>
        /// <param name="skin">The skin code representing the character's appearance.</param>
        /// <exception cref="CharacterNameHasDisallowedCharacters">Thrown when <paramref name="name"/> contains not allowed characters. Should match pattern ^[a-zA-Z0-9_-]+$</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> is not between 3 and 12 characters long.</exception>
        public CreateCharacterRequest(string name, SkinCode skin)
        {
            Name = name;
            Skin = skin;

            _validator.Validate(this);
        }

        /// <summary>
        /// Your desired character name. It's unique and all players can see it.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Your desired skin.
        /// </summary>
        public SkinCode Skin { get; }
    }
}
