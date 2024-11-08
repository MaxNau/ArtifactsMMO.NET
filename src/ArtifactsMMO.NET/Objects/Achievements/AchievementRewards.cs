using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Achievements
{
    /// <summary>
    /// Achievement rewards
    /// </summary>
    public class AchievementRewards
    {
        internal AchievementRewards() { }

        [JsonConstructor]
        internal AchievementRewards(int gold)
        {
            Gold = gold;
        }

        /// <summary>
        /// Gold rewards.
        /// </summary>
        public int Gold { get; }
    }
}
