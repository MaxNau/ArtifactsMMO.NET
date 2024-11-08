namespace ArtifactsMMO.NET.Enums.ErrorCodes.Action
{
    /// <summary>
    /// Grand Exchange cancel sell order action error codes
    /// </summary>
    public enum GrandExchangeCancelSellOrderError
    {
        /// <summary>
        /// Order not found.
        /// </summary>
        OrderNotFound = 404,

        /// <summary>
        /// A transaction is already in progress on this order by a another character.
        /// </summary>
        TransactionInProgressByAnotherCharacter = 436,

        /// <summary>
        /// You can't cancel an order that is not yours.
        /// </summary>
        CannotCancelNotOwnOrder = 438,

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
        /// Grand Exchange not found on this map.
        /// </summary>
        GrandExchangeNotFoundOnTheMap = 598,
    }
}
