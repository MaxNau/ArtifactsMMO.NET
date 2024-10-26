using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Validators;

namespace ArtifactsMMO.NET.Requests
{
    /// <summary>
    /// Request to craft an item.
    /// </summary>
    public class CraftingRequest : IRequest
    {
        private static readonly IValidator<CraftingRequest> _validator = new CraftingRequestValidator();

        /// <summary>
        /// Initializes a new instance of the <see cref="CraftingRequest"/> class.
        /// </summary>
        /// <param name="code">The code representing the item to be crafted.</param>
        /// <param name="quantity">The optional number of items to craft. If set to null defaults to 1.</param>
        /// <exception cref="ItemCodeHasDisallowedCharacters">Thrown when <paramref name="code"/> contains not allowed characters. Should match pattern ^[a-zA-Z0-9_-]+$</exception>
        /// <exception cref="DisallowedQuantity">Thrown when <paramref name="quantity"/> is less then 1.</exception>
        public CraftingRequest(string code, int? quantity = null)
        {
            Code = code;
            Quantity = quantity;

            _validator.Validate(this);
        }

        /// <summary>
        /// Craft code.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Quantity of items to craft.
        /// </summary>
        public int? Quantity { get; }
    }
}
