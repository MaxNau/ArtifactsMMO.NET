using ArtifactsMMO.NET.Enums;
using System;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Achievements
{
    /// <summary>
    /// Account achievement details
    /// </summary>
    public class AccountAchievement
    {
        internal AccountAchievement() { }

        [JsonConstructor]
        internal AccountAchievement(string name, string code, string description, int points, AchievementType type,
            string target, int total, AchievementRewards rewards, int current, DateTimeOffset? completedAt)
        {
            Name = name;
            Code = code;
            Description = description;
            Points = points;
            Type = type;
            Target = target;
            Total = total;
            Rewards = rewards;
            Current = current;
            CompletedAt = completedAt;
        }

        /// <summary>
        /// Name of the achievement.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Code of the achievement.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Description of the achievement.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Points of the achievement.
        /// </summary>
        /// <remarks>
        /// Used for the leaderboard.
        /// </remarks>
        public int Points { get; }

        /// <summary>
        /// Type of achievement.
        /// </summary>
        public AchievementType Type { get; }

        /// <summary>
        /// Target of the achievement.
        /// </summary>
        public string Target { get; }

        /// <summary>
        /// Total to do.
        /// </summary>
        public int Total { get; }

        /// <summary>
        /// Rewards.
        /// </summary>
        public AchievementRewards Rewards { get; }

        /// <summary>
        /// Current progress.
        /// </summary>
        public int Current { get; }

        /// <summary>
        /// Completed at.
        /// </summary>
        public DateTimeOffset? CompletedAt { get; }
    }
}
