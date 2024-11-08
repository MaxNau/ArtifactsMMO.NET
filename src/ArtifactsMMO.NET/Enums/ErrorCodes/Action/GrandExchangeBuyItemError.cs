namespace ArtifactsMMO.NET.Enums.ErrorCodes.Action
{
    /// <summary>
    /// Grand Exchange buy item action error codes
    /// </summary>
    public enum GrandExchangeBuyItemError
    {
        /// <summary>
        /// Order not found.
        /// </summary>
        OrderNotFound = 404,

        /// <summary>
        /// This offer does not contain as many items.
        /// </summary>
        InsufficientItems = 434,

        /// <summary>
        /// You can't buy to yourself.
        /// </summary>
        CannotBuySelf = 435,

        /// <summary>
        /// A transaction is already in progress on this order by a another character.
        /// </summary>
        TransactionInProgressByAnotherCharacter = 436,

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
        /// Grand Exchange not found on this map.
        /// </summary>
        GrandExchangeNotFoundOnTheMap = 598,
    }
}
