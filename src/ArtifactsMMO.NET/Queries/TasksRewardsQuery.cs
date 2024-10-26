using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Internal;
using System.Text.Json;

namespace ArtifactsMMO.NET.Queries
{
    /// <summary>
    /// Represents a query for retrieving task rewards, inheriting from <see cref="PaginationQuery"/> 
    /// and implementing <see cref="IQueryString"/> for API request handling.
    /// </summary>
    /// <remarks>
    /// This class is used to construct queries that include pagination parameters for retrieving task rewards.
    /// </remarks>
    public class TasksRewardsQuery : PaginationQuery, IQueryString
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TasksRewardsQuery"/> class with no pagination parameters.
        /// </summary>
        public TasksRewardsQuery() : base(null, null) { HasParameters = false; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TasksRewardsQuery"/> class with specified pagination parameters.
        /// </summary>
        /// <param name="page">The page number for pagination.</param>
        /// <param name="size">The number of items per page.</param>
        /// <exception cref="InvalidQueryParameter"></exception>
        public TasksRewardsQuery(int? page = null, int? size = null) : base(page, size)
        {
        }

        string IQueryString.ToQueryString()
        {
            if (!HasParameters)
            {
                return string.Empty;
            }

            var queryStringBuilder = new QueryStringBuilder();
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Page)), Page?.ToString());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Size)), Size?.ToString());

            return queryStringBuilder.ToString();
        }
    }
}
