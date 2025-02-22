using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using ArtifactsMMO.NET.Enums;

namespace ArtifactsMMO.NET.Objects.Characters
{
    /// <summary>
    /// Character details.
    /// </summary>
    public class Character
    {
        internal Character() { }

        [JsonConstructor]
        internal Character(string name, SkinCode skin, int level, int xp, int maxXp, int achievementsPoints,
            int gold, int speed, int miningLevel, int miningXp, int miningMaxXp, int woodcuttingLevel,
            int woodcuttingXp, int woodcuttingMaxXp, int fishingLevel, int fishingXp, int fishingMaxXp,
            int weaponcraftingLevel, int weaponcraftingXp, int weaponcraftingMaxXp, int gearcraftingLevel,
            int gearcraftingXp, int gearcraftingMaxXp, int jewelrycraftingLevel, int jewelrycraftingXp,
            int jewelrycraftingMaxXp, int cookingLevel, int cookingXp, int cookingMaxXp, int alchemyLevel,
            int alchemyXp, int alchemyMaxXp, int hp, int haste, string account, int criticalStrike, int wisdom,
            int prospecting, int attackFire, int attackEarth, int attackWater,int attackAir, int dmg, int dmgFire,
            int dmgEarth, int dmgWater, int dmgAir, int resFire,int resEarth, int resWater,
            int resAir, int x, int y, int cooldown, DateTimeOffset? cooldownExpiration, string weaponSlot,
            string shieldSlot, string helmetSlot, string bodyArmorSlot, string legArmorSlot, string bootsSlot,
            string ring1Slot, string ring2Slot, string amuletSlot, string artifact1Slot, string artifact2Slot,
            string artifact3Slot, string utility1Slot, int utility1SlotQuantity, string utility2Slot,
            int utility2SlotQuantity, string bagSlot, string runeSlot, string task, string taskType, int taskProgress,
            int taskTotal, int inventoryMaxItems, int maxHp, IReadOnlyCollection<InventorySlot> inventory)
        {
            Name = name;
            Account = account;
            Skin = skin;
            Level = level;
            Xp = xp;
            MaxXp = maxXp;
            AchievementsPoints = achievementsPoints;
            Gold = gold;
            Speed = speed;
            MiningLevel = miningLevel;
            MiningXp = miningXp;
            MiningMaxXp = miningMaxXp;
            WoodcuttingLevel = woodcuttingLevel;
            WoodcuttingXp = woodcuttingXp;
            WoodcuttingMaxXp = woodcuttingMaxXp;
            FishingLevel = fishingLevel;
            FishingXp = fishingXp;
            FishingMaxXp = fishingMaxXp;
            WeaponcraftingLevel = weaponcraftingLevel;
            WeaponcraftingXp = weaponcraftingXp;
            WeaponcraftingMaxXp = weaponcraftingMaxXp;
            GearcraftingLevel = gearcraftingLevel;
            GearcraftingXp = gearcraftingXp;
            GearcraftingMaxXp = gearcraftingMaxXp;
            JewelrycraftingLevel = jewelrycraftingLevel;
            JewelrycraftingXp = jewelrycraftingXp;
            JewelrycraftingMaxXp = jewelrycraftingMaxXp;
            CookingLevel = cookingLevel;
            CookingXp = cookingXp;
            CookingMaxXp = cookingMaxXp;
            AlchemyLevel = alchemyLevel;
            AlchemyXp = alchemyXp;
            AlchemyMaxXp = alchemyMaxXp;
            Hp = hp;
            Haste = haste;
            CriticalStrike = criticalStrike;
            Wisdom = wisdom;
            Prospecting = prospecting;
            AttackFire = attackFire;
            AttackEarth = attackEarth;
            AttackWater = attackWater;
            AttackAir = attackAir;
            Dmg = dmg;
            DmgFire = dmgFire;
            DmgEarth = dmgEarth;
            DmgWater = dmgWater;
            DmgAir = dmgAir;
            ResFire = resFire;
            ResEarth = resEarth;
            ResWater = resWater;
            ResAir = resAir;
            X = x;
            Y = y;
            Cooldown = cooldown;
            CooldownExpiration = cooldownExpiration;
            WeaponSlot = weaponSlot;
            ShieldSlot = shieldSlot;
            HelmetSlot = helmetSlot;
            BodyArmorSlot = bodyArmorSlot;
            LegArmorSlot = legArmorSlot;
            BootsSlot = bootsSlot;
            Ring1Slot = ring1Slot;
            Ring2Slot = ring2Slot;
            AmuletSlot = amuletSlot;
            Artifact1Slot = artifact1Slot;
            Artifact2Slot = artifact2Slot;
            Artifact3Slot = artifact3Slot;
            Utility1Slot = utility1Slot;
            Utility1SlotQuantity = utility1SlotQuantity;
            Utility2Slot = utility2Slot;
            Utility2SlotQuantity = utility2SlotQuantity;
            BagSlot = bagSlot;
            RuneSlot = runeSlot;
            Task = task;
            TaskType = taskType;
            TaskProgress = taskProgress;
            TaskTotal = taskTotal;
            InventoryMaxItems = inventoryMaxItems;
            MaxHp = maxHp;
            Inventory = inventory;
        }

        /// <summary>
        /// Name of the character.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Account name.
        /// </summary>
        public string Account { get; }

        /// <summary>
        /// Character skin code.
        /// </summary>
        public SkinCode Skin { get; }

        /// <summary>
        /// Combat level.
        /// </summary>
        public int Level { get; }

        /// <summary>
        /// The current xp level of the combat level.
        /// </summary>
        public int Xp { get; }

        /// <summary>
        /// XP required to level up the character.
        /// </summary>
        public int MaxXp { get; }

        /// <summary>
        /// Achievements points.
        /// </summary>
        public int AchievementsPoints { get; }

        /// <summary>
        /// The numbers of gold on this character.
        /// </summary>
        public int Gold { get; }

        /// <summary>
        /// *Not available, on the roadmap. Character movement speed.
        /// </summary>
        public int Speed { get; }

        /// <summary>
        /// Mining level.
        /// </summary>
        public int MiningLevel { get; }

        /// <summary>
        /// The current xp level of the Mining skill.
        /// </summary>
        public int MiningXp { get; }

        /// <summary>
        /// Mining XP required to level up the skill.
        /// </summary>
        public int MiningMaxXp { get; }

        /// <summary>
        /// Woodcutting level.
        /// </summary>
        public int WoodcuttingLevel { get; }

        /// <summary>
        /// The current xp level of the Woodcutting skill.
        /// </summary>
        public int WoodcuttingXp { get; }

        /// <summary>
        /// Woodcutting XP required to level up the skill.
        /// </summary>
        public int WoodcuttingMaxXp { get; }

        /// <summary>
        /// Fishing level.
        /// </summary>
        public int FishingLevel { get; }

        /// <summary>
        /// The current xp level of the Fishing skill.
        /// </summary>
        public int FishingXp { get; }

        /// <summary>
        /// Fishing XP required to level up the skill.
        /// </summary>
        public int FishingMaxXp { get; }

        /// <summary>
        /// Weaponcrafting level.
        /// </summary>
        public int WeaponcraftingLevel { get; }

        /// <summary>
        /// The current xp level of the Weaponcrafting skill.
        /// </summary>
        public int WeaponcraftingXp { get; }

        /// <summary>
        /// Weaponcrafting XP required to level up the skill.
        /// </summary>
        public int WeaponcraftingMaxXp { get; }

        /// <summary>
        /// Gearcrafting level.
        /// </summary>
        public int GearcraftingLevel { get; }

        /// <summary>
        /// The current xp level of the Gearcrafting skill.
        /// </summary>
        public int GearcraftingXp { get; }

        /// <summary>
        /// Gearcrafting XP required to level up the skill.
        /// </summary>
        public int GearcraftingMaxXp { get; }

        /// <summary>
        /// Jewelrycrafting level.
        /// </summary>
        public int JewelrycraftingLevel { get; }

        /// <summary>
        /// The current xp level of the Jewelrycrafting skill.
        /// </summary>
        public int JewelrycraftingXp { get; }

        /// <summary>
        /// Jewelrycrafting XP required to level up the skill.
        /// </summary>
        public int JewelrycraftingMaxXp { get; }

        /// <summary>
        /// The current xp level of the Cooking skill.
        /// </summary>
        public int CookingLevel { get; }

        /// <summary>
        /// Cooking XP.
        /// </summary>
        public int CookingXp { get; }

        /// <summary>
        /// Cooking XP required to level up the skill.
        /// </summary>
        public int CookingMaxXp { get; }

        /// <summary>
        /// The current xp level of the Alchemy skill.
        /// </summary>
        public int AlchemyLevel { get; }

        /// <summary>
        /// Alchemy XP.
        /// </summary>
        public int AlchemyXp { get; }

        /// <summary>
        /// Alchemy XP required to level up the skill.
        /// </summary>
        public int AlchemyMaxXp { get; }

        /// <summary>
        /// Character HP.
        /// </summary>
        public int Hp { get; }

        /// <summary>
        /// *Increase speed attack (reduce fight cooldown)
        /// </summary>
        public int Haste { get; }

        /// <summary>
        /// % Critical strike. Critical strikes increase the attack's damage by 30%.
        /// </summary>
        public int CriticalStrike { get; }

        /// <summary>
        /// Wisdom increases the amount of XP gained from fights.
        /// </summary>
        public int Wisdom { get; }

        /// <summary>
        /// Prospecting increases the chances of getting better loot.
        /// </summary>
        public int Prospecting { get; }

        /// <summary>
        /// Fire attack.
        /// </summary>
        public int AttackFire { get; }

        /// <summary>
        /// Earth attack.
        /// </summary>
        public int AttackEarth { get; }

        /// <summary>
        /// Water attack.
        /// </summary>
        public int AttackWater { get; }

        /// <summary>
        /// Air attack.
        /// </summary>
        public int AttackAir { get; }

        /// <summary>
        /// % Damage. Damage increases your attack in all elements.
        /// </summary>
        public int Dmg { get; }

        /// <summary>
        /// % Fire damage. Damage increases your fire attack.
        /// </summary>
        public int DmgFire { get; }

        /// <summary>
        /// % Earth damage. Damage increases your earth attack.
        /// </summary>
        public int DmgEarth { get; }

        /// <summary>
        /// % Water damage. Damage increases your water attack.
        /// </summary>
        public int DmgWater { get; }

        /// <summary>
        /// % Air damage. Damage increases your air attack.
        /// </summary>
        public int DmgAir { get; }

        /// <summary>
        /// % Fire resistance. Reduces fire attack.
        /// </summary>
        public int ResFire { get; }

        /// <summary>
        /// % Earth resistance. Reduces earth attack.
        /// </summary>
        public int ResEarth { get; }

        /// <summary>
        /// % Water resistance. Reduces water attack.
        /// </summary>
        public int ResWater { get; }

        /// <summary>
        /// % Air resistance. Reduces air attack.
        /// </summary>
        public int ResAir { get; }

        /// <summary>
        /// Character x coordinate.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Character y coordinate.
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Cooldown in seconds.
        /// </summary>
        public int Cooldown { get; }

        /// <summary>
        /// Datetime Cooldown expiration.
        /// </summary>
        public DateTimeOffset? CooldownExpiration { get; }

        /// <summary>
        /// Weapon slot.
        /// </summary>
        public string WeaponSlot { get; }

        /// <summary>
        /// Shield slot.
        /// </summary>
        public string ShieldSlot { get; }

        /// <summary>
        /// Helmet slot.
        /// </summary>
        public string HelmetSlot { get; }

        /// <summary>
        /// Body armor slot.
        /// </summary>
        public string BodyArmorSlot { get; }

        /// <summary>
        /// Leg armor slot.
        /// </summary>
        public string LegArmorSlot { get; }

        /// <summary>
        /// Boots slot.
        /// </summary>
        public string BootsSlot { get; }

        /// <summary>
        /// Ring 1 slot.
        /// </summary>
        public string Ring1Slot { get; }

        /// <summary>
        /// Ring 2 slot.
        /// </summary>
        public string Ring2Slot { get; }

        /// <summary>
        /// Amulet slot.
        /// </summary>
        public string AmuletSlot { get; }

        /// <summary>
        /// Artifact 1 slot.
        /// </summary>
        public string Artifact1Slot { get; }

        /// <summary>
        /// Artifact 2 slot.
        /// </summary>
        public string Artifact2Slot { get; }


        /// <summary>
        /// Artifact 3 slot.
        /// </summary>
        public string Artifact3Slot { get; }

        /// <summary>
        /// Utility first slot.
        /// </summary>
        public string Utility1Slot { get; }

        /// <summary>
        /// Utility first slot quantity.
        /// </summary>
        public int Utility1SlotQuantity { get; }

        /// <summary>
        /// Utility second slot.
        /// </summary>
        public string Utility2Slot { get; }

        /// <summary>
        /// Utility second slot quantity.
        /// </summary>
        public int Utility2SlotQuantity { get; }

        /// <summary>
        /// Bag slot.
        /// </summary>
        public string BagSlot { get; }

        /// <summary>
        /// Rune slot.
        /// </summary>
        public string RuneSlot { get; }

        /// <summary>
        /// Task in progress.
        /// </summary>
        public string Task { get; }

        /// <summary>
        /// Task type.
        /// </summary>
        public string TaskType { get; }

        /// <summary>
        /// Task progression.
        /// </summary>
        public int TaskProgress { get; }

        /// <summary>
        /// Task total objective.
        /// </summary>
        public int TaskTotal { get; }

        /// <summary>
        /// Inventory max items.
        /// </summary>
        public int InventoryMaxItems { get; }

        /// <summary>
        /// Character max HP.
        /// </summary>
        public int MaxHp { get; }

        /// <summary>
        /// List of inventory slots.
        /// </summary>
        public IReadOnlyCollection<InventorySlot> Inventory { get; }
    }
}
