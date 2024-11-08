
using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Internal;
using System.Text.Json;

namespace ArtifactsMMO.NET.Queries
{
    /// <summary>
    /// Represents a query for retrieving sales history with pagination support.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="PaginationQuery"/> and implements <see cref="IQueryString"/> 
    /// to facilitate the construction of query strings for API requests.
    /// </remarks>
    public class MyGrandExchangeOrderHistoryQuery : PaginationQuery, IQueryString
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyGrandExchangeOrderHistoryQuery"/> class with specified pagination settings.
        /// </summary>
        public MyGrandExchangeOrderHistoryQuery() : base(null, null)
        {
            HasParameters = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyGrandExchangeOrderHistoryQuery"/> class with specified pagination settings.
        /// </summary>
        /// <param name="code">The optional code of the item.</param>
        /// <param name="id">The optional id of the order.</param>
        /// <param name="page">The optional page number for pagination.</param>
        /// <param name="size">The optional page size for pagination.</param>
        /// <exception cref="InvalidQueryParameter"></exception>
        public MyGrandExchangeOrderHistoryQuery(string code = null, string id = null, 
            int? page = null, int? size = null) : base(page, size)
        {
            Code = code;
            Id = id;
        }

        /// <summary>
        /// Item to search in your history.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Order ID to search in your history.
        /// </summary>
        public string Id { get; }

        string IQueryString.ToQueryString()
        {
            if (!HasParameters)
            {
                return string.Empty;
            }

            var queryStringBuilder = new QueryStringBuilder();
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Code)), Code);
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Id)), Id);
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Page)), Page?.ToString());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Size)), Size?.ToString());

            return queryStringBuilder.ToString();
        }
    }
}
