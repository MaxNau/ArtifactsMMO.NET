using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Validators;

namespace ArtifactsMMO.NET.Requests
{
    /// <summary>
    /// Request to unequip an item on your character.
    /// </summary>
    public class UnequipItemReguest : IRequest
    {
        private static readonly IValidator<UnequipItemReguest> _validator = new UnequipItemRequestValidator();

        /// <summary>
        /// Initializes a new instance of the <see cref="UnequipItemReguest"/> class.
        /// </summary>
        /// <param name="slot">The item slot from which to unequip the item. See <see cref="ItemSlot"/> for valid slots.</param>
        /// <param name="quantity">The quantity of the item to unequip. Defaults to 1. Applicable to consumables only for other types of items should not be set.</param>
        /// <exception cref="DisallowedConsumablesQuantity">Thrown when <paramref name="quantity"/> is not from 1 to 100 inclusive Applicable to consumables only.</exception>
        /// <exception cref="DisallowedItemQuantity">Thrown when <paramref name="quantity"/> is not equal to 1. Applicable to non-consumables.</exception>
        public UnequipItemReguest(ItemSlot slot, int? quantity = null)
        {
            Slot = slot;
            Quantity = quantity;

            _validator.Validate(this);
        }

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
