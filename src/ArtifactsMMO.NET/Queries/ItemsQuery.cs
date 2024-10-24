using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Internal;
using ArtifactsMMO.NET.Validators;
using System.Text.Json;

namespace ArtifactsMMO.NET.Queries
{
    /// <summary>
    /// Represents a query for retrieving items, supporting pagination and various filtering options.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="PaginationQuery"/> and implements <see cref="IQueryString"/> 
    /// to facilitate the construction of query strings for API requests.
    /// </remarks>
    public class ItemsQuery : PaginationQuery, IQueryString
    {
        private static readonly IValidator<ItemsQuery> _validator = new ItemsQueryValidator();

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemsQuery"/> class with no parameters.
        /// </summary>
        public ItemsQuery() : base(null, null)
        {
            HasParameters = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemsQuery"/> class with specified filtering options.
        /// </summary>
        /// <param name="craftMaterial">The material used for crafting the item.</param>
        /// <param name="craftSkill">The crafting skill required to use the item e.g., <see cref="CraftSkill"/>.</param>
        /// <param name="name">The name of the item.</param>
        /// <param name="type">The type of the item, e.g., <see cref="ItemType"/>.</param>
        /// <param name="minLevel">The minimum level required to use the item.</param>
        /// <param name="maxLevel">The maximum level required to use the item.</param>
        /// <param name="page">The page number for pagination.</param>
        /// <param name="size">The number of items per page.</param>
        /// <exception cref="InvalidQueryParameter"></exception>
        public ItemsQuery(string craftMaterial = null, CraftSkill? craftSkill = null, string name = null,
            ItemType? type = null, int? minLevel = null, int? maxLevel = null ,int? page = null,
            int? size = null) : base(page, size)
        {
            CraftMaterial = craftMaterial;
            CraftSkill = craftSkill;
            Name = name;
            Type = type;
            MinLevel = minLevel;
            MaxLevel = maxLevel;

            _validator.Validate(this);
        }

        /// <summary>
        /// Item code of items used as material for crafting.
        /// </summary>
        public string CraftMaterial { get; }

        /// <summary>
        /// Skill to craft items.
        /// </summary>
        public CraftSkill? CraftSkill { get; }

        /// <summary>
        /// Name of the item.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Type of items (see <see cref="ItemType"/> for possible values).
        /// </summary>
        public ItemType? Type { get; }

        /// <summary>
        /// Minimum level items.
        /// </summary>
        public int? MinLevel { get; }

        /// <summary>
        /// Maximum level items.
        /// </summary>
        public int? MaxLevel { get; }

        string IQueryString.ToQueryString()
        {
            if (!HasParameters)
            {
                return string.Empty;
            }

            var queryStringBuilder = new QueryStringBuilder();
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(CraftMaterial)), CraftMaterial);
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(CraftSkill)), CraftSkill?.ToString());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Name)), Name);
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Type)), Type?.ToString());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(MaxLevel)), MaxLevel?.ToString());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(MinLevel)), MinLevel?.ToString());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Page)), Page?.ToString());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Size)), Size?.ToString());

            return queryStringBuilder.ToString();
        }
    }
}
