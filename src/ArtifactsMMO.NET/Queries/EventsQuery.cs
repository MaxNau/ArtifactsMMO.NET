using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Internal;
using System.Text.Json;

namespace ArtifactsMMO.NET.Queries
{
    /// <summary>
    /// Represents a query for retrieving events with pagination support.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="PaginationQuery"/> and implements <see cref="IQueryString"/> 
    /// to facilitate the construction of query strings for API requests.
    /// </remarks>
    public class EventsQuery : PaginationQuery, IQueryString
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventsQuery"/> class with no parameters.
        /// </summary>
        public EventsQuery() : base(null, null)
        {
            HasParameters = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventsQuery"/> class with specified pagination settings.
        /// </summary>
        /// <param name="page">The optional page number for pagination.</param>
        /// <param name="size">The optional page size for pagination.</param>
        /// <exception cref="InvalidQueryParameter"></exception>
        public EventsQuery(int? page = null, int? size = null) : base(page, size)
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
