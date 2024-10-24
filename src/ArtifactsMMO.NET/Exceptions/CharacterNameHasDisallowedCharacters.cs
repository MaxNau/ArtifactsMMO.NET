using System;

namespace ArtifactsMMO.NET.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when a character name contains disallowed characters.
    /// </summary>
    /// <remarks>
    /// This exception indicates that the provided character name does not comply with the 
    /// allowed character set, which includes letters (A-Z, a-z), numbers (0-9), underscores (_), 
    /// and hyphens (-). 
    /// </remarks>
    public class CharacterNameHasDisallowedCharacters : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterNameHasDisallowedCharacters"/> class 
        /// with a default error message.
        /// </summary>
        internal CharacterNameHasDisallowedCharacters()
            : base("Invalid character name! Please use only letters (A-Z, a-z), numbers (0-9), underscores (_), and hyphens (-).")
        {
        }
    }
}
