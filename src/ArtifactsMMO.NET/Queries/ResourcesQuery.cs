using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Internal;
using ArtifactsMMO.NET.Validators;
using System.Text.Json;

namespace ArtifactsMMO.NET.Queries
{
    /// <summary>
    /// Represents a query for retrieving resources, supporting pagination and filtering by drop and gathering skill.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="PaginationQuery"/> and implements <see cref="IQueryString"/> 
    /// to facilitate the construction of query strings for API requests.
    /// </remarks>
    public class ResourcesQuery : PaginationQuery, IQueryString
    {
        private readonly static IValidator<ResourcesQuery> _validator = new ResourcesQueryValidator();

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourcesQuery"/> class with no parameters.
        /// </summary>
        public ResourcesQuery() : base(null, null) { HasParameters = false; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourcesQuery"/> class with specified parameters.
        /// </summary>
        /// <param name="drop">The item that the resource drops.</param>
        /// <param name="skill">The gathering skill associated with the resource.</param>
        /// <param name="maxLevel">The maximum level of the resource.</param>
        /// <param name="minLevel">The minimum level of the resource.</param>
        /// <param name="page">The page number for pagination.</param>
        /// <param name="size">The number of items per page for pagination.</param>
        /// <exception cref="InvalidQueryParameter"></exception>
        public ResourcesQuery(string drop = null, GatheringSkill? skill = null, int? maxLevel = null,
            int? minLevel = null, int? page = null, int? size = null)
            : base(page, size)
        {
            Drop = drop;
            Skill = skill;
            MaxLevel = maxLevel;
            MinLevel = minLevel;

            _validator.Validate(this);
        }

        /// <summary>
        /// Item that the resource drops.
        /// </summary>
        public string Drop { get; }

        /// <summary>
        /// Gathering skill associated with the resource.
        /// </summary>
        public GatheringSkill? Skill { get; }

        /// <summary>
        /// Maximum level of the resource.
        /// </summary>
        public int? MaxLevel { get; }

        /// <summary>
        /// Minimum level of the resource.
        /// </summary>
        public int? MinLevel { get; }

        string IQueryString.ToQueryString()
        {
            if (!HasParameters)
            {
                return string.Empty;
            }

            var queryStringBuilder = new QueryStringBuilder();
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Drop)), Drop);
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Skill)),
                JsonNamingPolicy.SnakeCaseLower.ConvertName(Skill?.ToString() ?? string.Empty));
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(MaxLevel)), MaxLevel?.ToString());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(MinLevel)), MinLevel?.ToString());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Page)), Page?.ToString());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Size)), Size?.ToString());

            return queryStringBuilder.ToString();
        }
    }
}
