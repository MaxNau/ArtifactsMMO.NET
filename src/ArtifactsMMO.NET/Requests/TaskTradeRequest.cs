using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Validators;

namespace ArtifactsMMO.NET.Requests
{
    /// <summary>
    /// Request to trade items with a Tasks Master
    /// </summary>
    public class TaskTradeRequest : IRequest
    {
        private static readonly IValidator<TaskTradeRequest> _validator = new TaskTradeRequestValidator();

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskTradeRequest"/> class.
        /// </summary>
        /// <param name="code">The code representing the item to be traded.</param>
        /// <param name="quantity">The number of items to be traded.</param>
        /// <exception cref="ItemCodeHasDisallowedCharacters">Thrown when <paramref name="code"/> contains not allowed characters. Should match pattern ^[a-zA-Z0-9_-]+$</exception>
        /// <exception cref="DisallowedQuantity">Thrown when <paramref name="quantity"/> is less then 1.</exception>
        public TaskTradeRequest(string code, int quantity)
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
