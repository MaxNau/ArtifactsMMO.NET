using System;

namespace ArtifactsMMO.NET.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when an invalid quantity is specified.
    /// </summary>
    /// <remarks>
    /// This exception indicates that the specified quantity must be greater than or equal to 1.
    /// Any quantity below this threshold is considered invalid and will trigger this exception.
    /// </remarks>
    public class DisallowedQuantity : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisallowedQuantity"/> class 
        /// with a default error message.
        /// </summary>
        internal DisallowedQuantity()
            : base("Must be greater than or equal to 1.")
        {
        }
    }
}
