using System;

namespace ArtifactsMMO.NET.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when an invalid price is specified.
    /// </summary>
    /// <remarks>
    /// This exception indicates that the specified price must be greater than or equal to 1
    /// and less or equal to 1000000000.
    /// Any price below this threshold is considered invalid and will trigger this exception.
    /// </remarks>
    public class DisallowedPrice : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisallowedPrice"/> class 
        /// with a default error message.
        /// </summary>
        internal DisallowedPrice()
            : base("Must be greater than or equal to 1 and less or equal to 1000000000.")
        {
        }
    }
}
