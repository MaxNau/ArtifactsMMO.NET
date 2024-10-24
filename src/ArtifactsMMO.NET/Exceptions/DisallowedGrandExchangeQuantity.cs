using System;

namespace ArtifactsMMO.NET.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when an invalid quantity for a Grand Exchange transaction is specified.
    /// </summary>
    /// <remarks>
    /// This exception indicates that the provided quantity for a Grand Exchange transaction 
    /// is outside the allowed range. The valid quantity must be between 1 and 100, inclusive.
    /// </remarks>
    public class DisallowedGrandExchangeQuantity : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisallowedGrandExchangeQuantity"/> class 
        /// with a default error message.
        /// </summary>
        internal DisallowedGrandExchangeQuantity()
            : base("Should be in range from 1 to 100 inclusive.")
        {
        }
    }
}
