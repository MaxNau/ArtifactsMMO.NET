using ArtifactsMMO.NET.Enums;
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
        internal AccountLeaderboard(int position, string account, int achievementsPoints,
           MemberStatus status)
        {
            Position = position;
            Account = account;
            AchievementsPoints = achievementsPoints;
            Status = status;
        }

        /// <summary>
        /// Position in the leaderboard.
        /// </summary>
        public int Position { get; }

        /// <summary>
        /// Account name.
        /// </summary>
        public string Account { get; }

        /// <summary>
        /// Member status.
        /// </summary>
        public MemberStatus Status { get; }

        /// <summary>
        /// Achievements points.
        /// </summary>
        public int AchievementsPoints { get; }
    }
}
