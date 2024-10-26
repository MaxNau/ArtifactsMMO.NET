using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Validators;

namespace ArtifactsMMO.NET.Requests
{
    /// <summary>
    /// Request to take an item from your bank and put it in the character's inventory.
    /// </summary>
    public class WithdrawBankRequest : IRequest
    {
        private static readonly IValidator<WithdrawBankRequest> _validator = new WithdrawBankRequestValidator();

        /// <summary>
        /// Initializes a new instance of the <see cref="WithdrawBankRequest"/> class.
        /// </summary>
        /// <param name="code">The code representing the item to be withdrawn from the bank.</param>
        /// <param name="quantity">The number of items to withdraw.</param>
        /// <exception cref="ItemCodeHasDisallowedCharacters">Thrown when <paramref name="code"/> contains not allowed characters. Should match pattern ^[a-zA-Z0-9_-]+$</exception>
        /// <exception cref="DisallowedQuantity">Thrown when <paramref name="quantity"/> is less then 1.</exception>
        public WithdrawBankRequest(string code, int quantity)
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
