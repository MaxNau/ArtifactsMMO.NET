using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Validators;

namespace ArtifactsMMO.NET.Requests
{
    /// <summary>
    /// Request to delete an item from your character's inventory.
    /// </summary>
    public class DeleteItemRequest : IRequest
    {
        private readonly static IValidator<DeleteItemRequest> _validator = new DeleteItemRequestValidator();

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteItemRequest"/> class.
        /// </summary>
        /// <param name="code">The code representing the item to be deleted.</param>
        /// <param name="quantity">The number of items to delete.</param>
        /// <exception cref="ItemCodeHasDisallowedCharacters">Thrown when <paramref name="code"/> contains not allowed characters. Should match pattern ^[a-zA-Z0-9_-]+$</exception>
        /// <exception cref="DisallowedQuantity">Thrown when <paramref name="quantity"/> is less then 1.</exception>
        public DeleteItemRequest(string code, int quantity)
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
