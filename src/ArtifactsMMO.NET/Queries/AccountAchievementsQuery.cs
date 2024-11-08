using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Internal;
using System.Text.Json;

namespace ArtifactsMMO.NET.Queries
{
    /// <summary>
    /// Represents a query for retrieving account achievements with pagination support.
    /// </summary>
    /// <remarks>
    /// This class extends <see cref="PaginationQuery"/> and implements <see cref="IQueryString"/>.
    /// </remarks>
    public class AccountAchievementsQuery : PaginationQuery, IQueryString
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountAchievementsQuery"/> class with no parameters.
        /// </summary>
        public AccountAchievementsQuery() : base(null, null)
        {
            HasParameters = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountAchievementsQuery"/> class with specified parameters.
        /// </summary>
        /// <param name="completed">ilter by completed achievements</param>
        /// <param name="type">The type of achievements to query. Optional.</param>
        /// <param name="page">The page number for pagination. Optional.</param>
        /// <param name="size">The number of items per page. Optional.</param>
        /// <exception cref="InvalidQueryParameter"></exception>
        public AccountAchievementsQuery(bool? completed, AchievementType? type = null,
            int? page = null, int? size = null)
            : base(page, size)
        {
            Completed = completed;
            Type = type;
        }

        /// <summary>
        /// Filter by completed achievements.
        /// </summary>
        public bool? Completed { get; }

        /// <summary>
        /// Optional type of achievements to filter by (see <see cref="AchievementType" /> for possible values).
        /// </summary>
        public AchievementType? Type { get; }

        string IQueryString.ToQueryString()
        {
            if (!HasParameters)
            {
                return string.Empty;
            }

            var queryStringBuilder = new QueryStringBuilder();
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Type)), Type?.ToString().ToLower());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Page)), Page?.ToString());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Size)), Size?.ToString());

            return queryStringBuilder.ToString();
        }
    }
}
