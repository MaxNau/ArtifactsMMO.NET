namespace ArtifactsMMO.NET.Enums.ErrorCodes.Action
{
    /// <summary>
    /// Equip item action error codes
    /// </summary>
    public enum EquipItemError
    {
        /// <summary>
        /// Item not found.
        /// </summary>
        ItemNotFound = 404,

        /// <summary>
        /// Missing item or insufficient quantity.
        /// </summary>
        MissingItemOrInsufficientQuantity = 478,

        /// <summary>
        /// Character can't equip more than 100 consumables in the same slot.
        /// </summary>
        EquipLimitExceeded = 484,

        /// <summary>
        /// This item is already equipped.
        /// </summary>
        ItemAlreadyEquipped = 485,

        /// <summary>
        /// An action is already in progress by your character.
        /// </summary>
        ActionInProgress = 486,

        /// <summary>
        /// Slot is not empty.
        /// </summary>
        SlotNotEmpty = 491,

        /// <summary>
        /// Character level is insufficient.
        /// </summary>
        InsufficientCharacterLevel = 496,

        /// <summary>
        /// Character inventory is full.
        /// </summary>
        InventoryFull = 497,

        /// <summary>
        /// Character not found.
        /// </summary>
        CharacterNotFound = 498,

        /// <summary>
        /// Character in cooldown.
        /// </summary>
        CharacterInCooldown = 499,
    }
}
