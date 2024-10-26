namespace ArtifactsMMO.NET.Enums.ErrorCodes.Action
{
    /// <summary>
    /// Recycling action error codes
    /// </summary>
    public enum RecyclingError
    {
        /// <summary>
        /// Item not found.
        /// </summary>
        ItemNotFound = 404,

        /// <summary>
        /// This item cannot be recycled.
        /// </summary>
        CannotBeRecycled = 473,

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
