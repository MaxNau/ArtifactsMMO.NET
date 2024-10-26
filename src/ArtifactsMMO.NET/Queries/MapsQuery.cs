using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Internal;
using ArtifactsMMO.NET.Validators;
using System.Text.Json;

namespace ArtifactsMMO.NET.Queries
{
    /// <summary>
    /// Represents a query for retrieving maps, supporting pagination and filtering by content.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="PaginationQuery"/> and implements <see cref="IQueryString"/> 
    /// to facilitate the construction of query strings for API requests.
    /// </remarks>
    public class MapsQuery : PaginationQuery, IQueryString
    {
        private static readonly IValidator<MapsQuery> _validator = new MapsQueryValidator();

        /// <summary>
        /// Initializes a new instance of the <see cref="MapsQuery"/> class with no parameters.
        /// </summary>
        public MapsQuery() : base(null, null) { HasParameters = false; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapsQuery"/> class with specified parameters.
        /// </summary>
        /// <param name="contentCode">The code of the content to filter the maps by.</param>
        /// <param name="contentType">The type of content to filter the maps by, such as monster or resource.
        /// If not content type provided all content types will be returned</param>
        /// <param name="page">The page number for pagination.</param>
        /// <param name="size">The number of items per page for pagination.</param>
        /// <exception cref="InvalidQueryParameter"></exception>
        public MapsQuery(string contentCode = null, MapContentType? contentType = null,
            int? page = null, int? size = null)
            : base(page, size)
        {
            ContentCode = contentCode;
            ContentType = contentType;

            _validator.Validate(this);
        }

        /// <summary>
        /// Code of the content to filter the maps by.
        /// </summary>
        public string ContentCode { get; }

        /// <summary>
        /// Type of content to filter the maps by.
        /// </summary>
        public MapContentType? ContentType { get; }

        string IQueryString.ToQueryString()
        {
            if (!HasParameters)
            {
                return string.Empty;
            }

            var queryStringBuilder = new QueryStringBuilder();
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(ContentCode)), ContentCode);
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(ContentType)), ContentType?.ToString().ToLower());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Page)), Page?.ToString());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Size)), Size?.ToString());

            return queryStringBuilder.ToString();
        }
    }
}
