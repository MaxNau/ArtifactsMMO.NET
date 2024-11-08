using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Leaderboard
{
    /// <summary>
    /// Account leaderboard details
    /// </summary>
    public class AccountLeaderboard
    {
       internal AccountLeaderboard() { }

       [JsonConstructor]
        internal AccountLeaderboard(string account, int achievementsPoints)
        {
            Account = account;
            AchievementsPoints = achievementsPoints;
        }

        /// <summary>
        /// Account name.
        /// </summary>
        public string Account { get; }

        /// <summary>
        /// Achievements points.
        /// </summary>
        public int AchievementsPoints { get; }
    }
}
