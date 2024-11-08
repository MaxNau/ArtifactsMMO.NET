using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Requests;
using ArtifactsMMO.NET.Validators.Static;

namespace ArtifactsMMO.NET.Validators
{
    internal class UseItemRequestValidator : IValidator<UseItemRequest>
    {
        public void Validate(UseItemRequest useItemRequest)
        {
            if (!AlphaNumericUnderscoreHyphenValidator.IsValid(useItemRequest.Code))
            {
                throw new ItemCodeHasDisallowedCharacters();
            }

            if (!QuantityValidator.IsValid(useItemRequest.Quantity))
            {
                throw new DisallowedQuantity();
            }
        }
    }
}
