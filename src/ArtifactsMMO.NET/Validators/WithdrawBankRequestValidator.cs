using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Requests;
using ArtifactsMMO.NET.Validators.Static;

namespace ArtifactsMMO.NET.Validators
{
    internal class WithdrawBankRequestValidator : IValidator<WithdrawBankRequest>
    {
        public void Validate(WithdrawBankRequest withdrawBankRequest)
        {
            if (!AlphaNumericUnderscoreHyphenValidator.IsValid(withdrawBankRequest.Code))
            {
                throw new ItemCodeHasDisallowedCharacters();
            }

            if (!QuantityValidator.IsValid(withdrawBankRequest.Quantity))
            {
                throw new DisallowedQuantity();
            }
        }
    }
}
