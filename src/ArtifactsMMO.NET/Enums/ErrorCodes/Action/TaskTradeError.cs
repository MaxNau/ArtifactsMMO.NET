namespace ArtifactsMMO.NET.Enums.ErrorCodes.Action
{
    /// <summary>
    /// Task trade action error codes
    /// </summary>
    public enum TaskTradeError
    {
        /// <summary>
        /// Character does not have this task.
        /// </summary>
        TaskNotFound = 474,

        /// <summary>
        /// Character have already completed the task or are trying to trade too many items.
        /// </summary>
        TaskAlreadyCompletedOrTooManyItems = 475,

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
        /// Tasks Master not found on this map.
        /// </summary>
        TasksMasterNotFoundOnTheMap = 598,
    }
}
