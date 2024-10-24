using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Requests;
using ArtifactsMMO.NET.Validators.Static;

namespace ArtifactsMMO.NET.Validators
{
    internal class DepositBankGoldRequestValidator : IValidator<DepositBankGoldRequest>
    {
        public void Validate(DepositBankGoldRequest depositBankGoldRequest)
        {
            if (!QuantityValidator.IsValid(depositBankGoldRequest.Quantity))
            {
                throw new DisallowedQuantity();
            }
        }
    }
}
