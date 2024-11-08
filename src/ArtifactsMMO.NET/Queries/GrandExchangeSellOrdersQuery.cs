using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Internal;
using System.Text.Json;

namespace ArtifactsMMO.NET.Queries
{
    /// <summary>
    /// Represents a query for retrieving sell orders details with pagination support.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="PaginationQuery"/> and implements <see cref="IQueryString"/> 
    /// to facilitate the construction of query strings for API requests.
    /// </remarks>
    public class GrandExchangeSellOrdersQuery : PaginationQuery, IQueryString
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GrandExchangeSellOrdersQuery"/> class with no parameters.
        /// </summary>
        public GrandExchangeSellOrdersQuery() : base(null, null)
        {
            HasParameters = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GrandExchangeSellOrdersQuery"/> class with specified pagination settings.
        /// </summary>
        /// <param name="code">The optional code of the item.</param>
        /// <param name="seller">The optional seller (account name) of the item.</param>
        /// <param name="page">The optional page number for pagination.</param>
        /// <param name="size">The optional page size for pagination.</param>
        /// <exception cref="InvalidQueryParameter"></exception>
        public GrandExchangeSellOrdersQuery(string code = null, string seller = null,
            int? page = null, int? size = null)
            : base(page, size)
        {
            Code = code;
            Seller = seller;
        }

        /// <summary>
        /// The code of the item.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// The seller (account name) of the item.
        /// </summary>
        public string Seller { get; }

        string IQueryString.ToQueryString()
        {
            if (!HasParameters)
            {
                return string.Empty;
            }

            var queryStringBuilder = new QueryStringBuilder();
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Code)), Code);
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Seller)), Seller);
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Page)), Page?.ToString());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Size)), Size?.ToString());

            return queryStringBuilder.ToString();
        }
    }
}
