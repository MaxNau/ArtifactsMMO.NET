using System;

namespace ArtifactsMMO.NET.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when an item code contains disallowed characters.
    /// </summary>
    /// <remarks>
    /// This exception is thrown when the item code provided in an API request 
    /// does not conform to the allowed character set. The error message specifies 
    /// the valid characters that can be used in an item code.
    /// </remarks>
    public class ItemCodeHasDisallowedCharacters : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemCodeHasDisallowedCharacters"/> class 
        /// with a default error message.
        /// </summary>
        internal ItemCodeHasDisallowedCharacters()
            : base("Invalid item code! Please use only letters (A-Z, a-z), numbers (0-9), underscores (_), and hyphens (-).")
        {
        }
    }
}
