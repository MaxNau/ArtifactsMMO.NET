using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Queries;
using ArtifactsMMO.NET.Validators.Static;

namespace ArtifactsMMO.NET.Validators
{
    internal class ResourcesQueryValidator : IValidator<ResourcesQuery>
    {
        public void Validate(ResourcesQuery resourcesQuery)
        {
            if (!AlphaNumericUnderscoreHyphenValidator.IsValid(resourcesQuery.Drop))
            {
                throw new InvalidQueryParameter(nameof(resourcesQuery.Drop), "Allowed values include letters (a-z, A-Z), digits (0-9), underscores (_), and hyphens (-), with no spaces or special characters.");
            }

            if (resourcesQuery.MaxLevel.HasValue && resourcesQuery.MaxLevel.Value < 0)
            {
                throw new InvalidQueryParameter(nameof(resourcesQuery.MaxLevel), ">=0");
            }

            if (resourcesQuery.MinLevel.HasValue && resourcesQuery.MinLevel.Value < 0)
            {
                throw new InvalidQueryParameter(nameof(resourcesQuery.MinLevel), ">=0");
            }
        }
    }
}
