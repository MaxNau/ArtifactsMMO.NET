namespace ArtifactsMMO.NET.Enums.ErrorCodes.Action
{
    /// <summary>
    /// Complete task action error codes
    /// </summary>
    public enum CompleteTaskError
    {
        /// <summary>
        /// An action is already in progress by your character.
        /// </summary>
        ActionInProgress = 486,

        /// <summary>
        /// Character has no task.
        /// </summary>
        NoTaskInProgress = 487,

        /// <summary>
        /// Character has not completed the task.
        /// </summary>
        TaskNotCompleted = 488,

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
