using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyAccount
{
    /// <summary>
    /// Represents the details of a user account.
    /// </summary>
    public class AccountDetails
    {
        internal AccountDetails() { }

        [JsonConstructor]
        internal AccountDetails(string username, string email, bool subscribed, int? subscribedUntil,
            bool founder, List<string> badges, int? gems, bool banned, string banReason)
        {
            Username = username;
            Email = email;
            Subscribed = subscribed;
            SubscribedUntil = subscribedUntil;
            Founder = founder;
            Badges = badges;
            Gems = gems;
            Banned = banned;
            BanReason = banReason;
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
        /// Season number until which the account is subscribed.
        /// </summary>
        public int? SubscribedUntil { get; }

        /// <summary>
        /// Value indicating whether the account is a founder account.
        /// </summary>
        public bool Founder { get; }

        /// <summary>
        /// List of badges earned by the account.
        /// </summary>
        public List<string> Badges { get; } = new List<string>();

        /// <summary>
        /// Number of gems the account currently holds.
        /// </summary>
        public int? Gems { get; }

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
