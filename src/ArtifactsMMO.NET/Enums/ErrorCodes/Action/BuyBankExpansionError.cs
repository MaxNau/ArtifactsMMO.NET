namespace ArtifactsMMO.NET.Enums.ErrorCodes.Action
{
    /// <summary>
    /// Buy bank expansion action error codes
    /// </summary>
    public enum BuyBankExpansionError
    {
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
        /// Bank not found on this map.
        /// </summary>
        BankNotFoundOnTheMap = 598,
    }
}
