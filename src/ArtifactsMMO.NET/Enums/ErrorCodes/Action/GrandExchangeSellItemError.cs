namespace ArtifactsMMO.NET.Enums.ErrorCodes.Action
{
    /// <summary>
    /// Grand Exchange sell item action error codes
    /// </summary>
    public enum GrandExchangeSellItemError
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
        /// You can't buy or sell that many items at the same time.
        /// </summary>
        ExcessiveQuantity = 479,

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
