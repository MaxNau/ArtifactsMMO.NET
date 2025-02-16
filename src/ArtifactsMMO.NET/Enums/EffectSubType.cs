namespace ArtifactsMMO.NET.Enums
{
    /// <summary>
    /// Enum representing the subtype of an effect.
    /// </summary>
    public enum EffectSubtype
    {
        /// <summary>
        /// Represents a stat effect, which may modify a character's statistics.
        /// </summary>
        Stat,

        /// <summary>
        /// Represents a generic effect that doesn't fit other categories.
        /// </summary>
        Other,

        /// <summary>
        /// Represents a healing effect that restores health or other resources.
        /// </summary>
        Heal,

        /// <summary>
        /// Represents a buff effect that enhances the character's abilities.
        /// </summary>
        Buff,

        /// <summary>
        /// Represents a debuff effect that weakens or limits the character's abilities.
        /// </summary>
        Debuff,

        /// <summary>
        /// Represents a special effect that doesn't fit into the standard categories.
        /// </summary>
        Special,

        /// <summary>
        /// Represents an effect related to gathering resources, such as harvesting or mining.
        /// </summary>
        Gathering,

        /// <summary>
        /// Represents an effect that teleports the character from one location to another.
        /// </summary>
        Teleport,

        /// <summary>
        /// Represents an effect related to gaining gold or currency.
        /// </summary>
        Gold
    }
}
