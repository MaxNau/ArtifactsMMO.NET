using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Internal;
using ArtifactsMMO.NET.Validators;
using System.Text.Json;

namespace ArtifactsMMO.NET.Queries
{
    /// <summary>
    /// Represents a query for retrieving monsters, supporting pagination and filtering by drop and level.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="PaginationQuery"/> and implements <see cref="IQueryString"/> 
    /// to facilitate the construction of query strings for API requests.
    /// </remarks>
    public class MonstersQuery : PaginationQuery, IQueryString
    {
        private static readonly IValidator<MonstersQuery> _validator = new MonstersQueryValidator();

        /// <summary>
        /// Initializes a new instance of the <see cref="MonstersQuery"/> class with no parameters.
        /// </summary>
        public MonstersQuery() : base(null, null) { HasParameters = false; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MonstersQuery"/> class with specified parameters.
        /// </summary>
        /// <param name="drop">The item that the monster drops.</param>
        /// <param name="minLevel">The minimum level of the monster.</param>
        /// <param name="maxLevel">The maximum level of the monster.</param>
        /// <param name="page">The page number for pagination.</param>
        /// <param name="size">The number of items per page for pagination.</param>
        /// <exception cref="InvalidQueryParameter"></exception>
        public MonstersQuery(string drop = null, int? minLevel = null, int? maxLevel = null, int? page = null,
            int? size = null) : base(page, size)
        {
            Drop = drop;
            MinLevel = minLevel;
            MaxLevel = maxLevel;

            _validator.Validate(this);
        }

        /// <summary>
        /// Item that the monster drops.
        /// </summary>
        public string Drop { get; }

        /// <summary>
        /// Minimum level of the monster.
        /// </summary>
        public int? MinLevel { get; }

        /// <summary>
        /// Maximum level of the monster.
        /// </summary>
        public int? MaxLevel { get; }

        string IQueryString.ToQueryString()
        {
            if (!HasParameters)
            {
                return string.Empty;
            }

            var queryStringBuilder = new QueryStringBuilder();
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Drop)), Drop);
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(MaxLevel)), MaxLevel?.ToString());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(MinLevel)), MinLevel?.ToString());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Page)), Page?.ToString());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Size)), Size?.ToString());

            return queryStringBuilder.ToString();
        }
    }
}
