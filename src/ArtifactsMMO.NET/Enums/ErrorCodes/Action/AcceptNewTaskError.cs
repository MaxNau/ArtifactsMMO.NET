namespace ArtifactsMMO.NET.Enums.ErrorCodes.Action
{
    /// <summary>
    /// Accept new task action error codes
    /// </summary>
    public enum AcceptNewTaskError
    {
        /// <summary>
        /// An action is already in progress by your character.
        /// </summary>
        ActionInProgress = 486,

        /// <summary>
        /// Character already has a task.
        /// </summary>
        TaskAlreadyInProgress = 489,

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
