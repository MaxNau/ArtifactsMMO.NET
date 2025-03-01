using System;

namespace ArtifactsMMO.NET.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when an invalid quantity for a NPC transaction is specified.
    /// </summary>
    /// <remarks>
    /// This exception indicates that the provided quantity for a NPC transaction 
    /// is outside the allowed range. The valid quantity must be between 1 and 100, inclusive.
    /// </remarks>
    public class DisallowedNpcQuantity : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisallowedNpcQuantity"/> class 
        /// with a default error message.
        /// </summary>
        internal DisallowedNpcQuantity()
            : base("Should be in range from 1 to 100 inclusive.")
        {
        }
    }
}
