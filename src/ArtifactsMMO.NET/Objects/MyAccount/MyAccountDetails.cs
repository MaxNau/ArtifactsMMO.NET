using ArtifactsMMO.NET.Enums;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyAccount
{
    /// <summary>
    /// Represents the details of a user account.
    /// </summary>
    public class MyAccountDetails
    {
        internal MyAccountDetails() { }

        [JsonConstructor]
        internal MyAccountDetails(string username, string email, bool subscribed, List<string> badges,
            int gems, bool banned, string banReason,int achievementsPoints, MemberStatus status)
        {
            Username = username;
            Email = email;
            Subscribed = subscribed;
            Badges = badges;
            Gems = gems;
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
        /// Email address associated with the account.
        /// </summary>
        public string Email { get; }

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
        public IReadOnlyCollection<object> Badges { get; } = new List<object>();

        /// <summary>
        /// Number of gems the account currently holds.
        /// </summary>
        public int Gems { get; }

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
