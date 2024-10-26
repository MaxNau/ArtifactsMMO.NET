using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Requests;
using ArtifactsMMO.NET.Validators.Static;

namespace ArtifactsMMO.NET.Validators
{
    internal class GrandExchangetemRequestValidator : IValidator<GrandExchangetemRequest>
    {
        public void Validate(GrandExchangetemRequest grandExchangetemRequest)
        {
            if (!AlphaNumericUnderscoreHyphenValidator.IsValid(grandExchangetemRequest.Code))
            {
                throw new ItemCodeHasDisallowedCharacters();
            }

            if (!QuantityValidator.IsValid(grandExchangetemRequest.Quantity))
            {
                throw new DisallowedGrandExchangeQuantity();
            }

            if (!QuantityValidator.IsValid(grandExchangetemRequest.Price))
            {
                throw new DisallowedPrice();
            }
        }
    }
}
