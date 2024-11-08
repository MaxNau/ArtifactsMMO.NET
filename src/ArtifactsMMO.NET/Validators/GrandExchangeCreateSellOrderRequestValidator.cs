using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Requests;
using ArtifactsMMO.NET.Validators.Static;

namespace ArtifactsMMO.NET.Validators
{
    internal class GrandExchangeCreateSellOrderRequestValidator : IValidator<GrandExchangeCreateSellOrderRequest>
    {
        public void Validate(GrandExchangeCreateSellOrderRequest request)
        {
            if (!AlphaNumericUnderscoreHyphenValidator.IsValid(request.Code))
            {
                throw new ItemCodeHasDisallowedCharacters();
            }

            if (!QuantityValidator.IsValid(request.Quantity))
            {
                throw new DisallowedGrandExchangeQuantity();
            }

            if (request.Price < 1 || request.Price > 1000000000)
            {
                throw new DisallowedPrice();
            }
        }
    }
}
