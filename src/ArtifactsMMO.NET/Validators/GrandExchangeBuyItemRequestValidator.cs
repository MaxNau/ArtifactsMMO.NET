using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Requests;
using ArtifactsMMO.NET.Validators.Static;

namespace ArtifactsMMO.NET.Validators
{
    internal class GrandExchangeBuyItemRequestValidator : IValidator<GrandExchangeBuyItemRequest>
    {
        public void Validate(GrandExchangeBuyItemRequest request)
        {
            if (!AlphaNumericUnderscoreHyphenValidator.IsValid(request.Code))
            {
                throw new ItemCodeHasDisallowedCharacters();
            }

            if (!QuantityValidator.IsValid(request.Quantity))
            {
                throw new DisallowedGrandExchangeQuantity();
            }
        }
    }
}
