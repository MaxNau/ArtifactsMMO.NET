using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Requests;
using ArtifactsMMO.NET.Validators.Static;

namespace ArtifactsMMO.NET.Validators
{
    internal class UnequipItemRequestValidator : IValidator<UnequipItemReguest>
    {
        public void Validate(UnequipItemReguest unequipItemReguest)
        {
            if (unequipItemReguest.Slot == ItemSlot.Utility1 || unequipItemReguest.Slot == ItemSlot.Utility2)
            {
                if (unequipItemReguest.Quantity.HasValue && !ConsumablesQuantityValidator.IsValid(unequipItemReguest.Quantity.Value))
                {
                    throw new DisallowedConsumablesQuantity();
                }
            }
            else
            {
                if (unequipItemReguest.Quantity.HasValue && !ItemQuantityValidator.IsValid(unequipItemReguest.Quantity.Value))
                {
                    throw new DisallowedItemQuantity();
                }
            }
        }
    }
}
