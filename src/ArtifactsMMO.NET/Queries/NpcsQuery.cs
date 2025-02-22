using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Internal;
using System.Text.Json;

namespace ArtifactsMMO.NET.Queries
{
    /// <summary>
    /// Represents a query for retrieving NPCs, supporting pagination and filtering by content.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="PaginationQuery"/> and implements <see cref="IQueryString"/> 
    /// to facilitate the construction of query strings for API requests.
    /// </remarks>
    public class NpcsQuery : PaginationQuery, IQueryString
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NpcsQuery"/> class with no parameters.
        /// </summary>
        public NpcsQuery() : base(null, null)
        {
            HasParameters = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapsQuery"/> class with specified parameters.
        /// </summary>
        /// <param name="type">The type of the NPC.
        /// If not content type provided all content types will be returned</param>
        /// <param name="page">The page number for pagination.</param>
        /// <param name="size">The number of items per page for pagination.</param>
        /// <exception cref="InvalidQueryParameter"></exception>
        public NpcsQuery(NpcType? type = null, int? page = null, int? size = null)
            : base(page, size)
        {
            Type = type;
        }

        /// <summary>
        /// Npc Type
        /// </summary>
        public NpcType? Type { get; }

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
