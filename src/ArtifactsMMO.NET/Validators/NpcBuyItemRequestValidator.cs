using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Requests;
using ArtifactsMMO.NET.Validators.Static;

namespace ArtifactsMMO.NET.Validators
{
    internal class NpcBuyItemRequestValidator : IValidator<NpcBuyItemRequest>
    {
        public void Validate(NpcBuyItemRequest request)
        {
            if (!AlphaNumericUnderscoreHyphenValidator.IsValid(request.Code))
            {
                throw new ItemCodeHasDisallowedCharacters();
            }

            if (!NpcQuantityValidator.IsValid(request.Quantity))
            {
                throw new DisallowedNpcQuantity();
            }
        }
    }
}
