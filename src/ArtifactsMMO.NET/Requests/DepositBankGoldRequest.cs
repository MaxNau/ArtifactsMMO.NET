using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Validators;

namespace ArtifactsMMO.NET.Requests
{
    /// <summary>
    /// Request to deposit golds in a bank
    /// </summary>
    public class DepositBankGoldRequest : IRequest
    {
        private readonly static IValidator<DepositBankGoldRequest> _validator = new DepositBankGoldRequestValidator();

        /// <summary>
        /// Initializes a new instance of the <see cref="DepositBankGoldRequest"/> class.
        /// </summary>
        /// <param name="quantity">The amount of gold to deposit into the bank.</param>
        /// <exception cref="DisallowedQuantity">Thrown when <paramref name="quantity"/> is less then 1.</exception>
        public DepositBankGoldRequest(int quantity)
        {
            Quantity = quantity;

            _validator.Validate(this);
        }

        /// <summary>
        /// Quantity of gold.
        /// </summary>
        public int Quantity { get; }
    }
}
