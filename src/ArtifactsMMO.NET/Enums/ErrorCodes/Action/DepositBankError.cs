namespace ArtifactsMMO.NET.Enums.ErrorCodes.Action
{
    /// <summary>
    /// Deposit bank action error codes
    /// </summary>
    public enum DepositBankError
    {
        /// <summary>
        /// Item not found.
        /// </summary>
        ItemNotFound = 404,

        /// <summary>
        /// A transaction is already in progress with this item/your gold in your bank.
        /// </summary>
        TransactionInProgress = 461,

        /// <summary>
        /// Your bank is full.
        /// </summary>
        BankIsFull = 462,

        /// <summary>
        /// Missing item or insufficient quantity.
        /// </summary>
        MissingItemOrInsufficientQuantity = 478,

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
        /// Bank not found on this map.
        /// </summary>
        BankNotFoundOnTheMap = 598,
    }
}
