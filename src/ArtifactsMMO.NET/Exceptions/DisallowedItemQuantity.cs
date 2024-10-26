using System;

namespace ArtifactsMMO.NET.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when an invalid quantity for an item is specified.
    /// </summary>
    /// <remarks>
    /// This exception indicates that the specified quantity for an item must be exactly 1.
    /// Any other value is considered invalid and will trigger this exception.
    /// </remarks>
    public class DisallowedItemQuantity : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisallowedItemQuantity"/> class 
        /// with a default error message.
        /// </summary>
        internal DisallowedItemQuantity()
            : base("Allowed quantity value is 1.")
        {
        }
    }
}
