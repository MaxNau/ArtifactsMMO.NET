using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Validators;

namespace ArtifactsMMO.NET.Requests
{
    /// <summary>
    /// Request to deposit an item in a bank.
    /// </summary>
    public class DepositBankRequest : IRequest
    {
        private readonly static IValidator<DepositBankRequest> _validator = new DepositBankRequestValidator();


        /// <summary>
        /// Initializes a new instance of the <see cref="DepositBankRequest"/> class.
        /// </summary>
        /// <param name="code">The code representing the item to be deposited in the bank.</param>
        /// <param name="quantity">The number of items to deposit.</param>
        /// <exception cref="ItemCodeHasDisallowedCharacters">Thrown when <paramref name="code"/> contains not allowed characters. Should match pattern ^[a-zA-Z0-9_-]+$</exception>
        /// <exception cref="DisallowedQuantity">Thrown when <paramref name="quantity"/> is less then 1.</exception>
        public DepositBankRequest(string code, int quantity)
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
