namespace ArtifactsMMO.NET.Enums.ErrorCodes.Action
{
    /// <summary>
    /// Withdraw bank gold action error codes
    /// </summary>
    public enum WithdrawBankGoldError
    {
        /// <summary>
        /// Insufficient golds in your bank.
        /// </summary>
        InsufficientGoldsOnBank = 460,

        /// <summary>
        /// A transaction is already in progress with this item/your golds in your bank.
        /// </summary>
        TransactionInProgress = 461,

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
