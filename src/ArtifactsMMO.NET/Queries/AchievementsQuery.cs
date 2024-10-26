using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Internal;
using System.Text.Json;

namespace ArtifactsMMO.NET.Queries
{
    /// <summary>
    /// Represents a query for retrieving achievements with pagination support.
    /// </summary>
    /// <remarks>
    /// This class extends <see cref="PaginationQuery"/> and implements <see cref="IQueryString"/>.
    /// </remarks>
    public class AchievementsQuery : PaginationQuery, IQueryString
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AchievementsQuery"/> class with no parameters.
        /// </summary>
        public AchievementsQuery() : base(null, null)
        {
            HasParameters = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AchievementsQuery"/> class with specified parameters.
        /// </summary>
        /// <param name="type">The type of achievements to query. Optional.</param>
        /// <param name="page">The page number for pagination. Optional.</param>
        /// <param name="size">The number of items per page. Optional.</param>
        /// <exception cref="InvalidQueryParameter"></exception>
        public AchievementsQuery(AchievementType? type = null, int? page = null, int? size = null) : base(page, size)
        {
            Type = type;
        }

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
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Type)), Type?.ToString());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Page)), Page?.ToString());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Size)), Size?.ToString());

            return queryStringBuilder.ToString();
        }
    }
}
