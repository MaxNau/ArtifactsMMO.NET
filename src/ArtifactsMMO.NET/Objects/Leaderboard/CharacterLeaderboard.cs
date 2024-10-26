using ArtifactsMMO.NET.Enums;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Leaderboard
{
    /// <summary>
    /// Character leaderboard details
    /// </summary>
    public class CharacterLeaderboard
    {
        internal CharacterLeaderboard() { }

        [JsonConstructor]
        internal CharacterLeaderboard(string name, SkinCode skin, int achievementsPoints, int level,
            int totalXp, int miningLevel, int miningTotalXp, int woodcuttingLevel,
            int woodcuttingTotalXp, int fishingLevel, int fishingTotalXp, int weaponcraftingLevel,
            int weaponcraftingTotalXp, int gearcraftingLevel, int gearcraftingTotalXp,
            int jewelrycraftingLevel, int jewelrycraftingTotalXp, int cookingLevel, int cookingTotalXp,
            int gold)
        {
            Name = name;
            Skin = skin;
            AchievementsPoints = achievementsPoints;
            Level = level;
            TotalXp = totalXp;
            MiningLevel = miningLevel;
            MiningTotalXp = miningTotalXp;
            WoodcuttingLevel = woodcuttingLevel;
            WoodcuttingTotalXp = woodcuttingTotalXp;
            FishingLevel = fishingLevel;
            FishingTotalXp = fishingTotalXp;
            WeaponcraftingLevel = weaponcraftingLevel;
            WeaponcraftingTotalXp = weaponcraftingTotalXp;
            GearcraftingLevel = gearcraftingLevel;
            GearcraftingTotalXp = gearcraftingTotalXp;
            JewelrycraftingLevel = jewelrycraftingLevel;
            JewelrycraftingTotalXp = jewelrycraftingTotalXp;
            CookingLevel = cookingLevel;
            CookingTotalXp = cookingTotalXp;
            Gold = gold;
        }

        /// <summary>
        /// Character name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Character skin code.
        /// </summary>
        public SkinCode Skin { get; }

        /// <summary>
        /// Achievements points.
        /// </summary>
        public int AchievementsPoints { get; }

        /// <summary>
        /// Combat level.
        /// </summary>
        public int Level { get; }

        /// <summary>
        /// Total XP of your character.
        /// </summary>
        public int TotalXp { get; }

        /// <summary>
        /// Mining level.
        /// </summary>
        public int MiningLevel { get; }

        /// <summary>
        /// Mining total xp.
        /// </summary>
        public int MiningTotalXp { get; }

        /// <summary>
        /// Woodcutting level.
        /// </summary>
        public int WoodcuttingLevel { get; }

        /// <summary>
        /// Woodcutting total xp.
        /// </summary>
        public int WoodcuttingTotalXp { get; }

        /// <summary>
        /// Fishing level.
        /// </summary>
        public int FishingLevel { get; }

        /// <summary>
        /// Fishing total xp.
        /// </summary>
        public int FishingTotalXp { get; }

        /// <summary>
        /// Weaponcrafting level.
        /// </summary>
        public int WeaponcraftingLevel { get; }

        /// <summary>
        /// Weaponcrafting total xp.
        /// </summary>
        public int WeaponcraftingTotalXp { get; }

        /// <summary>
        /// Gearcrafting level.
        /// </summary>
        public int GearcraftingLevel { get; }

        /// <summary>
        /// Gearcrafting total xp.
        /// </summary>
        public int GearcraftingTotalXp { get; }

        /// <summary>
        /// Jewelrycrafting level.
        /// </summary>
        public int JewelrycraftingLevel { get; }

        /// <summary>
        /// Jewelrycrafting total xp.
        /// </summary>
        public int JewelrycraftingTotalXp { get; }

        /// <summary>
        /// Cooking level.
        /// </summary>
        public int CookingLevel { get; }

        /// <summary>
        /// Cooking total xp.
        /// </summary>
        public int CookingTotalXp { get; }

        /// <summary>
        /// The numbers of golds on this character.
        /// </summary>
        public int Gold { get; }
    }
}
