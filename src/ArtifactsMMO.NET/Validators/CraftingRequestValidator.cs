using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Requests;
using ArtifactsMMO.NET.Validators.Static;

namespace ArtifactsMMO.NET.Validators
{
    internal class CraftingRequestValidator : IValidator<CraftingRequest>
    {
        public void Validate(CraftingRequest craftingRequest)
        {
            if (!AlphaNumericUnderscoreHyphenValidator.IsValid(craftingRequest.Code))
            {
                throw new ItemCodeHasDisallowedCharacters();
            }

            if (craftingRequest.Quantity.HasValue && !QuantityValidator.IsValid(craftingRequest.Quantity.Value))
            {
                throw new DisallowedQuantity();
            }
        }
    }
}
