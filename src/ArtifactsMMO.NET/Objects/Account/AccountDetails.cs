using ArtifactsMMO.NET.Enums;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Account
{
    /// <summary>
    /// Account details
    /// </summary>
    public class AccountDetails
    {
        internal AccountDetails() { }

        [JsonConstructor]
        internal AccountDetails(string username, bool subscribed, IReadOnlyCollection<object> badges, bool banned,
            string banReason, int achievementsPoints, MemberStatus status)
        {
            Username = username;
            Subscribed = subscribed;
            Badges = badges;
            Banned = banned;
            BanReason = banReason;
            AchievementsPoints = achievementsPoints;
            Status = status;
        }

        /// <summary>
        /// Username of the account.
        /// </summary>
        public string Username { get; }

        /// <summary>
        /// Value indicating whether the account is subscribed for the current season.
        /// </summary>
        public bool Subscribed { get; }

        /// <summary>
        /// Achievement points.
        /// </summary>
        public int AchievementsPoints { get; }

        /// <summary>
        /// Member status.
        /// </summary>
        public MemberStatus Status { get; }

        /// <summary>
        /// List of badges earned by the account.
        /// </summary>
        public IReadOnlyCollection<object> Badges { get; }

        /// <summary>
        /// Value indicating whether the account is banned.
        /// </summary>
        public bool Banned { get; }

        /// <summary>
        /// Reason for the account's ban, if applicable.
        /// </summary>
        public string BanReason { get; }
    }
}
