using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Requests;
using ArtifactsMMO.NET.Validators.Static;

namespace ArtifactsMMO.NET.Validators
{
    internal class RecyclingRequestValidator : IValidator<RecyclingRequest>
    {
        public void Validate(RecyclingRequest recyclingRequest)
        {
            if (!AlphaNumericUnderscoreHyphenValidator.IsValid(recyclingRequest.Code))
            {
                throw new ItemCodeHasDisallowedCharacters();
            }

            if (recyclingRequest.Quantity.HasValue && !QuantityValidator.IsValid(recyclingRequest.Quantity.Value))
            {
                throw new DisallowedQuantity();
            }
        }
    }
}
