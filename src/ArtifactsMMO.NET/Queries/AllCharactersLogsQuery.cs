using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Internal;
using System.Text.Json;

namespace ArtifactsMMO.NET.Queries
{
    /// <summary>
    /// Represents a query for retrieving all character logs with pagination support.
    /// </summary>
    /// <remarks>
    /// This class extends <see cref="PaginationQuery"/> and implements <see cref="IQueryString"/>.
    /// </remarks>
    public class AllCharactersLogsQuery : PaginationQuery, IQueryString
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AllCharactersLogsQuery"/> class with no parameters.
        /// </summary>
        public AllCharactersLogsQuery() : base(null, null)
        {
            HasParameters = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AllCharactersLogsQuery"/> class with specified pagination parameters.
        /// </summary>
        /// <param name="page">The page number for pagination. Optional.</param>
        /// <param name="size">The number of items per page. Optional.</param>
        /// <exception cref="InvalidQueryParameter"></exception>
        public AllCharactersLogsQuery(int? page = null, int? size = null) : base(page, size)
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
