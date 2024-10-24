namespace ArtifactsMMO.NET.Enums.ErrorCodes.Action
{
    /// <summary>
    /// Move action error codes
    /// </summary>
    public enum MoveError
    {
        /// <summary>
        /// Map not found.
        /// </summary>
        MapNotFound = 404,

        /// <summary>
        /// An action is already in progress by your character.
        /// </summary>
        ActionInProgress = 486,

        /// <summary>
        /// Character already at destination.
        /// </summary>
        AlreadyAtDestination = 490,

        /// <summary>
        /// Character not found.
        /// </summary>
        CharacterNotFound = 498,

        /// <summary>
        /// Character in cooldown.
        /// </summary>
        CharacterInCooldown = 499,
    }
}
