using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Validators;

namespace ArtifactsMMO.NET.Requests
{
    /// <summary>
    /// Request to crate sell order at the Grand Exchange
    /// </summary>
    public class GrandExchangeCreateSellOrderRequest : IRequest
    {
        private static readonly IValidator<GrandExchangeCreateSellOrderRequest> _validator = new GrandExchangeCreateSellOrderRequestValidator();

        /// <summary>
        /// Initializes a new instance of the <see cref="GrandExchangeCreateSellOrderRequest"/> class.
        /// </summary>
        /// <param name="code">The code representing the item to buy or sell at the Grand Exchange.</param>
        /// <param name="quantity">The number of items to buy/sell.</param>
        /// <param name="price">The price at which the item will be bought/sold.</param>
        /// <exception cref="ItemCodeHasDisallowedCharacters">Thrown when <paramref name="code"/> contains not allowed characters. Should match pattern ^[a-zA-Z0-9_-]+$</exception>
        /// <exception cref="DisallowedGrandExchangeQuantity">Thrown when <paramref name="quantity"/> is not from 1 to 100 inclusive.</exception>
        /// <exception cref="DisallowedPrice">Thrown when <paramref name="price"/> is less then 1 or greater then 1000000000.</exception>
        public GrandExchangeCreateSellOrderRequest(string code, int quantity, int price)
        {
            Code = code;
            Quantity = quantity;
            Price = price;

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

        /// <summary>
        /// Item price.
        /// </summary>
        public int Price { get; }
    }
}
