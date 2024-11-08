namespace ArtifactsMMO.NET.Enums.ErrorCodes.Action
{
    /// <summary>
    /// Grand Exchange create sell order action error codes
    /// </summary>
    public enum GrandExchangeCreateSellOrderError
    {
        /// <summary>
        /// Item not found.
        /// </summary>
        ItemNotFound = 404,

        /// <summary>
        /// You can't create more than 100 orders at the same time.
        /// </summary>
        OrderCreationLimit = 433,

        /// <summary>
        /// Missing item or insufficient quantity.
        /// </summary>
        MissingItemOrInsufficientQuantity = 478,

        /// <summary>
        /// An action is already in progress by your character.
        /// </summary>
        ActionInProgress = 486,

        /// <summary>
        /// Insufficient gold on your character.
        /// </summary>
        InsufficientGoldOnCharacter = 492,

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
