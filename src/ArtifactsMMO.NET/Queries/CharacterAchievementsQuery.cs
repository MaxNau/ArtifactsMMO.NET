using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Internal;
using System.Text.Json;

namespace ArtifactsMMO.NET.Queries
{
    /// <summary>
    /// Represents a query for retrieving character achievements with optional filters and pagination.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="PaginationQuery"/> and implements <see cref="IQueryString"/> 
    /// to facilitate the construction of query strings for API requests.
    /// </remarks>
    public class CharacterAchievementsQuery : PaginationQuery, IQueryString
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterAchievementsQuery"/> class with no parameters.
        /// </summary>
        public CharacterAchievementsQuery() : base(null, null)
        {
            HasParameters = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterAchievementsQuery"/> class with specified filters and pagination settings.
        /// </summary>
        /// <param name="type">The optional type of achievements to filter by. If null, all types are returned.</param>
        /// <param name="completed">An optional flag indicating whether to filter by completed achievements. If null, both completed and incomplete achievements are returned.</param>
        /// <param name="page">The optional page number for pagination.</param>
        /// <param name="size">The optional page size for pagination.</param>
        /// <exception cref="InvalidQueryParameter"></exception>
        public CharacterAchievementsQuery(AchievementType? type = null, bool? completed = null,
            int? page = null, int? size = null)
            : base(page, size)
        {
            Type = type;
            Completed = completed;
        }

        /// <summary>
        /// Optional flag indicating whether the achievements should be completed.
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
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Completed)), Completed?.ToString());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Page)), Page?.ToString());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Size)), Size?.ToString());

            return queryStringBuilder.ToString();
        }
    }
}
