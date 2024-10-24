using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Queries;

namespace ArtifactsMMO.NET.Validators
{
    internal class PaginationQueryValidator : IValidator<PaginationQuery>
    {
        public void Validate(PaginationQuery paginationQuery)
        {
            if (paginationQuery.Page.HasValue && paginationQuery.Page.Value < 1)
            {
                throw new InvalidQueryParameter(nameof(paginationQuery.Page), "Must be greater or equal 1.");
            }

            if (paginationQuery.Size.HasValue && (paginationQuery.Size.Value < 1 || paginationQuery.Size.Value > 100))
            {
                throw new InvalidQueryParameter(nameof(paginationQuery.Size), "Must be in range from 1 to 100 inclusive.");
            }
        }
    }
}
