namespace ArtifactsMMO.NET.Enums.ErrorCodes.Action
{
    /// <summary>
    /// Npc sell item action error codes
    /// </summary>
    public enum NpcSellItemError
    {
        /// <summary>
        /// Item not found.
        /// </summary>
        ItemNotFound = 404,

        /// <summary>
        /// This item cannot be sold.
        /// </summary>
        ItemCannotBeSold = 442,

        /// <summary>
        /// Missing item or insufficient quantity.
        /// </summary>
        MissingItemOrInsufficientQuantity = 478,

        /// <summary>
        /// An action is already in progress by your character.
        /// </summary>
        ActionInProgress = 486,

        /// <summary>
        /// Character inventory is full.
        /// </summary>
        CharacterInventoryIsFull = 497,

        /// <summary>
        /// Character not found.
        /// </summary>
        CharacterNotFound = 498,

        /// <summary>
        /// Character in cooldown.
        /// </summary>
        CharacterInCooldown = 499,

        /// <summary>
        /// NPC not found on this map.
        /// </summary>
        NpcNotFoundOnTheMap = 598,
    }
}
