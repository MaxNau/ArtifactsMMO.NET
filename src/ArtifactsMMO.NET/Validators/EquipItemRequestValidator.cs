using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Requests;
using ArtifactsMMO.NET.Validators.Static;

namespace ArtifactsMMO.NET.Validators
{
    internal class EquipItemRequestValidator : IValidator<EquipItemRequest>
    {
        public void Validate(EquipItemRequest equipItemRequest)
        {
            if (!AlphaNumericUnderscoreHyphenValidator.IsValid(equipItemRequest.Code))
            {
                throw new ItemCodeHasDisallowedCharacters();
            }

            if (equipItemRequest.Slot == ItemSlot.Consumable1 || equipItemRequest.Slot == ItemSlot.Consumable2)
            {
                if (equipItemRequest.Quantity.HasValue && !ConsumablesQuantityValidator.IsValid(equipItemRequest.Quantity.Value))
                {
                    throw new DisallowedConsumablesQuantity();
                }
            }
            else
            {
                if (equipItemRequest.Quantity.HasValue && !ItemQuantityValidator.IsValid(equipItemRequest.Quantity.Value))
                {
                    new DisallowedItemQuantity();
                }
            }
        }
    }
}
