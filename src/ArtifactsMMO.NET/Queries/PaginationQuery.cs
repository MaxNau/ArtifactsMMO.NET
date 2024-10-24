using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Validators;

namespace ArtifactsMMO.NET.Queries
{
    /// <summary>
    /// Represents a base class for pagination queries, providing properties for page number and page size.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="BaseQuery"/> and is intended to be used as a base for query classes
    /// that require pagination parameters.
    /// </remarks>
    public abstract class PaginationQuery : BaseQuery
    {
        private static readonly IValidator<PaginationQuery> _validator = new PaginationQueryValidator();

        /// <summary>
        /// Initializes a new instance of the <see cref="PaginationQuery"/> class.
        /// </summary>
        /// <param name="page">The page number (optional).</param>
        /// <param name="size">The number of items per page (optional).</param>
        /// <exception cref="InvalidQueryParameter"></exception>
        protected PaginationQuery(int? page, int? size)
        {
            Page = page;
            Size = size;

            _validator.Validate(this);
        }

        /// <summary>
        /// Page number for the query.
        /// </summary>
        public int? Page { get; }

        /// <summary>
        /// Number of items per page for the query.
        /// </summary>
        public int? Size { get; }
    }
}
