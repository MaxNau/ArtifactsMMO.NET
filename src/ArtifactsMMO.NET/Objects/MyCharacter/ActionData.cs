using ArtifactsMMO.NET.Objects.Characters;

namespace ArtifactsMMO.NET.Objects.MyCharacter
{
    /// <summary>
    /// Represents the base class for action data in the game, 
    /// encapsulating the details related to a specific action, 
    /// including cooldown information and the character performing the action.
    /// </summary>
    public abstract class ActionData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionData"/> class.
        /// This constructor is protected and should be used by derived classes.
        /// </summary>
        protected ActionData() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionData"/> class with specified cooldown and character.
        /// </summary>
        /// <param name="cooldown">The cooldown period for the action.</param>
        /// <param name="character">The character performing the action.</param>
        protected ActionData(Cooldown cooldown, Character character)
        {
            Cooldown = cooldown;
            Character = character;
        }

        /// <summary>
        /// Cooldown information associated with the action.
        /// </summary>
        public Cooldown Cooldown { get; }

        /// <summary>
        /// Character that is performing the action.
        /// </summary>
        public Character Character { get; }
    }
}
