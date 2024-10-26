using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Validators;

namespace ArtifactsMMO.NET.Requests
{
    /// <summary>
    /// Request to recycle an item.
    /// </summary>
    public class RecyclingRequest : IRequest
    {
        private static readonly IValidator<RecyclingRequest> _validator = new RecyclingRequestValidator();

        /// <summary>
        /// Initializes a new instance of the <see cref="RecyclingRequest"/> class.
        /// </summary>
        /// <param name="code">The code representing the item to be recycled.</param>
        /// <param name="quantity">The optional number of items to recycle. If set to null defaults to 1.</param>
        /// <exception cref="ItemCodeHasDisallowedCharacters">Thrown when <paramref name="code"/> contains not allowed characters. Should match pattern ^[a-zA-Z0-9_-]+$</exception>
        /// <exception cref="DisallowedQuantity">Thrown when <paramref name="quantity"/> is less then 1.</exception>
        public RecyclingRequest(string code, int? quantity = null)
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
        /// Quantity of items to recycle.
        /// </summary>
        public int? Quantity { get; }
    }
}
