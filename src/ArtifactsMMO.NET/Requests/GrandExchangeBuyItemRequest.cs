using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Validators;

namespace ArtifactsMMO.NET.Requests
{
    /// <summary>
    /// Request to buy an item at the Grand Exchange
    /// </summary>
    public class GrandExchangeBuyItemRequest : IRequest
    {
        private static readonly IValidator<GrandExchangeBuyItemRequest> _validator = new GrandExchangeBuyItemRequestValidator();

        /// <summary>
        /// Initializes a new instance of the <see cref="GrandExchangeBuyItemRequest"/> class.
        /// </summary>
        /// <param name="code">The code representing the item to buy at the Grand Exchange.</param>
        /// <param name="quantity">The number of items to buy.</param>
        /// <exception cref="ItemCodeHasDisallowedCharacters">Thrown when <paramref name="code"/> contains not allowed characters. Should match pattern ^[a-zA-Z0-9_-]+$</exception>
        /// <exception cref="DisallowedGrandExchangeQuantity">Thrown when <paramref name="quantity"/> is not from 1 to 100 inclusive.</exception>
        public GrandExchangeBuyItemRequest(string code, int quantity)
        {
            Code = code;
            Quantity = quantity;

            _validator.Validate(this);
        }

        /// <summary>
        /// Item code.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Item quantity.
        /// </summary>
        public int Quantity { get; }
    }
}
