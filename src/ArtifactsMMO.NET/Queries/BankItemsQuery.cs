using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Internal;
using ArtifactsMMO.NET.Validators;
using System.Text.Json;

namespace ArtifactsMMO.NET.Queries
{
    /// <summary>
    /// Represents a query for retrieving bank items with optional pagination.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="PaginationQuery"/> and implements <see cref="IQueryString"/> 
    /// to facilitate the construction of query strings for API requests.
    /// </remarks>
    public class BankItemsQuery : PaginationQuery, IQueryString
    {
        private readonly static IValidator<BankItemsQuery> _validator = new BankItemsQueryValidator();

        /// <summary>
        /// Initializes a new instance of the <see cref="BankItemsQuery"/> class with no parameters.
        /// </summary>
        public BankItemsQuery() : base(null, null)
        {
            HasParameters = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BankItemsQuery"/> class with the specified item code and pagination settings.
        /// </summary>
        /// <param name="itemCode">The optional item code to filter the bank items. If null, all items are returned.</param>
        /// <param name="page">The optional page number for pagination.</param>
        /// <param name="size">The optional page size for pagination.</param>
        /// <exception cref="InvalidQueryParameter"></exception>
        public BankItemsQuery(string itemCode = null, int? page = null, int? size = null) : base(page, size)
        {
            ItemCode = itemCode;

            _validator.Equals(itemCode);
        }

        /// <summary>
        /// Optional item code used to filter the bank items.
        /// </summary>
        public string ItemCode { get; }

        string IQueryString.ToQueryString()
        {
            if (!HasParameters)
            {
                return string.Empty;
            }

            var queryStringBuilder = new QueryStringBuilder();
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(ItemCode)), ItemCode);
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Page)), Page?.ToString());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Size)), Size?.ToString());

            return queryStringBuilder.ToString();
        }
    }
}
