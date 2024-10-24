using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Requests;
using ArtifactsMMO.NET.Validators.Static;

namespace ArtifactsMMO.NET.Validators
{
    internal class WithdrawBankGoldRequestValidator : IValidator<WithdrawBankGoldRequest>
    {
        public void Validate(WithdrawBankGoldRequest withdrawBankGoldRequest)
        {
            if (!QuantityValidator.IsValid(withdrawBankGoldRequest.Quantity))
            {
                throw new DisallowedQuantity();
            }
        }
    }
}
