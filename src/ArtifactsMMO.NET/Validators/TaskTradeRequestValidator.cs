using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Requests;
using ArtifactsMMO.NET.Validators.Static;

namespace ArtifactsMMO.NET.Validators
{
    internal class TaskTradeRequestValidator : IValidator<TaskTradeRequest>
    {
        public void Validate(TaskTradeRequest taskTradeRequest)
        {
            if (!AlphaNumericUnderscoreHyphenValidator.IsValid(taskTradeRequest.Code))
            {
                throw new ItemCodeHasDisallowedCharacters();
            }

            if (!QuantityValidator.IsValid(taskTradeRequest.Quantity))
            {
                throw new DisallowedQuantity();
            }
        }
    }
}
