namespace ArtifactsMMO.NET.Enums.ErrorCodes.Action
{
    /// <summary>
    /// Fight action error codes
    /// </summary>
    public enum FightError
    {
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
        /// Monster not found on this map.
        /// </summary>
        MonsterNotFoundOnTheMap = 598,
    }
}
