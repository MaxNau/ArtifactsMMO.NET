namespace ArtifactsMMO.NET.Enums.ErrorCodes.Action
{
    /// <summary>
    /// Npc buy item action error codes
    /// </summary>
    public enum NpcBuyItemError
    {
        /// <summary>
        /// Item not found.
        /// </summary>
        ItemNotFound = 404,

        /// <summary>
        /// This item cannot be purchased.
        /// </summary>
        ItemCannotBePurchased = 441,

        /// <summary>
        /// An action is already in progress by your character.
        /// </summary>
        ActionInProgress = 486,

        /// <summary>
        /// Insufficient gold on your character.
        /// </summary>
        InsufficientGoldOnCharacter = 492,

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
