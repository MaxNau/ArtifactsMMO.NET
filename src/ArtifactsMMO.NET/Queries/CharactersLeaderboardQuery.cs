using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Internal;
using System.Text.Json;

namespace ArtifactsMMO.NET.Queries
{
    /// <summary>
    /// Represents a query for retrieving characters leaderboard data, including pagination and sorting options.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="PaginationQuery"/> and implements <see cref="IQueryString"/> 
    /// to facilitate the construction of query strings for API requests.
    /// </remarks>
    public class CharactersLeaderboardQuery : PaginationQuery, IQueryString
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CharactersLeaderboardQuery"/> class 
        /// with no parameters.
        /// </summary>
        public CharactersLeaderboardQuery() : base(null, null)
        {
            HasParameters = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CharactersLeaderboardQuery"/> class 
        /// with specified sorting, page, and size parameters.
        /// </summary>
        /// <param name="sort">The <see cref="LeaderboardSort"/> criteria to sort the leaderboard. Default sort by combat total XP.</param>
        /// <param name="page">The page number for pagination.</param>
        /// <param name="size">The number of items per page for pagination.</param>
        /// <exception cref="InvalidQueryParameter"></exception>
        public CharactersLeaderboardQuery(LeaderboardSort? sort = null, int? page = null, int? size = null)
            : base(page, size)
        {
            Sort = sort;
        }

        /// <summary>
        /// Sorting criteria for the leaderboard.
        /// </summary>
        public LeaderboardSort? Sort { get; }

        string IQueryString.ToQueryString()
        {
            if (!HasParameters)
            {
                return string.Empty;
            }

            var queryStringBuilder = new QueryStringBuilder();
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Sort)), Sort?.ToString().ToLower());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Page)), Page?.ToString());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Size)), Size?.ToString());

            return queryStringBuilder.ToString();
        }
    }
}
