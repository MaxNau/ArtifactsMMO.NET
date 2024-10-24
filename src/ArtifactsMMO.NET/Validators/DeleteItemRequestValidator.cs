using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Requests;
using ArtifactsMMO.NET.Validators.Static;

namespace ArtifactsMMO.NET.Validators
{
    internal class DeleteItemRequestValidator : IValidator<DeleteItemRequest>
    {
        public void Validate(DeleteItemRequest deleteItemRequest)
        {
            if (!AlphaNumericUnderscoreHyphenValidator.IsValid(deleteItemRequest.Code))
            {
                throw new ItemCodeHasDisallowedCharacters();
            }

            if (!QuantityValidator.IsValid(deleteItemRequest.Quantity))
            {
                throw new DisallowedQuantity();
            }
        }
    }
}
