namespace ArtifactsMMO.NET.Enums.ErrorCodes.Action
{
    /// <summary>
    /// Grand Exchange buy item action error codes
    /// </summary>
    public enum GrandExchangeBuyItemError
    {
        /// <summary>
        /// You can't buy or sell that many items at the same time.
        /// </summary>
        ExcessiveQuantity = 479,

        /// <summary>
        /// No stock for this item.
        /// </summary>
        NoStock = 480,

        /// <summary>
        /// No item at this price.
        /// </summary>
        NoItemAtPrice = 482,

        /// <summary>
        /// A transaction is already in progress on this item by a another character.
        /// </summary>
        TransactionInProgress = 483,

        /// <summary>
        /// An action is already in progress by your character.
        /// </summary>
        ActionInProgress = 486,

        /// <summary>
        /// Insufficient golds on your character.
        /// </summary>
        InsufficientGoldsOnCharacter = 492,

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
