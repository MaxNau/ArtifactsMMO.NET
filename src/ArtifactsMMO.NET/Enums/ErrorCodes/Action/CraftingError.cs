namespace ArtifactsMMO.NET.Enums.ErrorCodes.Action
{
    /// <summary>
    /// Crafting action error codes
    /// </summary>
    public enum CraftingError
    {
        /// <summary>
        /// Craft not found.
        /// </summary>
        CraftNotFound = 404,

        /// <summary>
        /// Missing item or insufficient quantity.
        /// </summary>
        MissingItemOrInsufficientQuantity = 478,

        /// <summary>
        /// An action is already in progress by your character.
        /// </summary>
        ActionInProgress = 486,

        /// <summary>
        /// Not skill level required.
        /// </summary>
        NotSkillLevelRequired = 493,

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

        /// <summary>
        /// Workshop not found on this map.
        /// </summary>
        WorkshopNotFoundOnTheMap = 598,
    }
}
