using System;

namespace ArtifactsMMO.NET.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when an invalid quantity of consumables is specified.
    /// </summary>
    /// <remarks>
    /// This exception indicates that the provided quantity for consumables is outside the 
    /// allowed range. The valid quantity must be between 1 and 100, inclusive.
    /// </remarks>
    public class DisallowedConsumablesQuantity : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisallowedConsumablesQuantity"/> class 
        /// with a default error message.
        /// </summary>
        internal DisallowedConsumablesQuantity()
            : base("Invalid consumables quantity. Should be in range from 1 to 100 inclusive.")
        {
        }
    }
}
