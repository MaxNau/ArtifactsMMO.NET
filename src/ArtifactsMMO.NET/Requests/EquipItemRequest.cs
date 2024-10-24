using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Validators;

namespace ArtifactsMMO.NET.Requests
{
    /// <summary>
    /// Request to equip an item on your character.
    /// </summary>
    public class EquipItemRequest : IRequest
    {
        private static readonly IValidator<EquipItemRequest> _itemCodeValidator = new EquipItemRequestValidator();

        /// <summary>
        /// Initializes a new instance of the <see cref="EquipItemRequest"/> class.
        /// </summary>
        /// <param name="code">The code of the item to be equipped. Must be a valid item code.</param>
        /// <param name="slot">The slot where the item will be equipped. See <see cref="ItemSlot"/> for valid slots.</param>
        /// <param name="quantity">The quantity of the item to equip. Defaults to 1 if set to null. Applicable to consumables only for other types of items should not be set.</param>
        /// <exception cref="ItemCodeHasDisallowedCharacters">Thrown when <paramref name="code"/> contains not allowed characters. Should match pattern ^[a-zA-Z0-9_-]+$</exception>
        /// <exception cref="DisallowedConsumablesQuantity">Thrown when <paramref name="quantity"/> is not from 1 to 100 inclusive. Applicable to consumables only.</exception>
        /// <exception cref="DisallowedItemQuantity">Thrown when <paramref name="quantity"/> is not equal to 1. Applicable to non-consumables.</exception>
        public EquipItemRequest(string code, ItemSlot slot, int? quantity = null)
        {
            Code = code;
            Slot = slot;
            Quantity = quantity;

            _itemCodeValidator.Validate(this);
        }

        /// <summary>
        /// Item code.
        /// </summary>
        public string Code { get; }
        
        /// <summary>
        /// Item slot.
        /// </summary>
        public ItemSlot Slot { get; }

        /// <summary>
        /// Item quantity. Applicable to consumables only.
        /// </summary>
        public int? Quantity { get; }
    }
}
