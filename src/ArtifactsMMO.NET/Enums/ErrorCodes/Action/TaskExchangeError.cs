namespace ArtifactsMMO.NET.Enums.ErrorCodes.Action
{
    /// <summary>
    /// Task exchange action error codes
    /// </summary>
    public enum TaskExchangeError
    {
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
        /// Tasks Master not found on this map.
        /// </summary>
        TasksMasterNotFoundOnTheMap = 598,
    }
}
