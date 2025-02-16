using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Internal;
using System.Text.Json;

namespace ArtifactsMMO.NET.Queries
{
    /// <summary>
    /// Represents a query for retrieving accounts leaderboard data, including pagination and sorting options.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="PaginationQuery"/> and implements <see cref="IQueryString"/> 
    /// to facilitate the construction of query strings for API requests.
    /// </remarks>
    public class AccountsLeaderboardQuery : PaginationQuery, IQueryString
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountsLeaderboardQuery"/> class 
        /// with specified sorting, page, and size parameters.
        /// </summary>
        /// <param name="page">The page number for pagination.</param>
        /// <param name="size">The number of items per page for pagination.</param>
        /// <param name="sort"></param>
        /// <exception cref="InvalidQueryParameter"></exception>
        public AccountsLeaderboardQuery(int? page, int? size, AccountLeaderboardSort? sort = null) : base(page, size)
        {
            Sort = sort;
        }

        /// <summary>
        /// Sort by
        /// </summary>
        public AccountLeaderboardSort? Sort { get; }

        string IQueryString.ToQueryString()
        {
            if (!HasParameters)
            {
                return string.Empty;
            }

            var queryStringBuilder = new QueryStringBuilder();
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Sort)),
                JsonNamingPolicy.SnakeCaseLower.ConvertName(Sort?.ToString() ?? string.Empty));
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Page)), Page?.ToString());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Size)), Size?.ToString());

            return queryStringBuilder.ToString();
        }
    }
}
