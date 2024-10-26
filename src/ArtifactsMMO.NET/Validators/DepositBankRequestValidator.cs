using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Requests;
using ArtifactsMMO.NET.Validators.Static;

namespace ArtifactsMMO.NET.Validators
{
    internal class DepositBankRequestValidator : IValidator<DepositBankRequest>
    {
        public void Validate(DepositBankRequest depositBankRequest)
        {
            if (!AlphaNumericUnderscoreHyphenValidator.IsValid(depositBankRequest.Code))
            {
                throw new ItemCodeHasDisallowedCharacters();
            }

            if (!QuantityValidator.IsValid(depositBankRequest.Quantity))
            {
                throw new DisallowedQuantity();
            }
        }
    }
}
