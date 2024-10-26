using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Validators;

namespace ArtifactsMMO.NET.Requests
{
    /// <summary>
    /// Request to withdraw gold from your bank.
    /// </summary>
    public class WithdrawBankGoldRequest : IRequest
    {
        private static readonly IValidator<WithdrawBankGoldRequest> _validator = new WithdrawBankGoldRequestValidator();

        /// <summary>
        /// Initializes a new instance of the <see cref="WithdrawBankGoldRequest"/> class.
        /// </summary>
        /// <param name="quantity">The amount of gold to withdraw from the bank.</param>
        /// <exception cref="DisallowedQuantity">Thrown when <paramref name="quantity"/> is less then 1.</exception>
        public WithdrawBankGoldRequest(int quantity)
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
