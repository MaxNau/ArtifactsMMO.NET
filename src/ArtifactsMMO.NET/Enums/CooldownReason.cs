namespace ArtifactsMMO.NET.Enums
{
    /// <summary>
    /// Represents the different reasons for cooldowns in the game.
    /// </summary>
    public enum CooldownReason
    {
        /// <summary>
        /// Cooldown due to character movement.
        /// </summary>
        Movement,

        /// <summary>
        /// Cooldown due to engaging in a fight.
        /// </summary>
        Fight,

        /// <summary>
        /// Cooldown due to crafting an item.
        /// </summary>
        Crafting,

        /// <summary>
        /// Cooldown due to gathering resources.
        /// </summary>
        Gathering,

        /// <summary>
        /// Cooldown due to buying on the Grand Exchange.
        /// </summary>
        BuyGe,

        /// <summary>
        /// Cooldown due to selling on the Grand Exchange.
        /// </summary>
        SellGe,

        /// <summary>
        /// Cooldown due to deleting an item.
        /// </summary>
        DeleteItem,

        /// <summary>
        /// Cooldown due to depositing items in the bank.
        /// </summary>
        DepositBank,

        /// <summary>
        /// Cooldown due to withdrawing items from the bank.
        /// </summary>
        WithdrawBank,

        /// <summary>
        /// Cooldown due to equipping an item.
        /// </summary>
        Equip,

        /// <summary>
        /// Cooldown due to unequipping an item.
        /// </summary>
        Unequip,

        /// <summary>
        /// Cooldown due to completing a task.
        /// </summary>
        Task,

        /// <summary>
        /// Cooldown due to recycling items.
        /// </summary>
        Recycling
    }
}
