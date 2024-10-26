using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Queries;
using ArtifactsMMO.NET.Validators.Static;

namespace ArtifactsMMO.NET.Validators
{
    internal class MonstersQueryValidator : IValidator<MonstersQuery>
    {
        public void Validate(MonstersQuery monstersQuery)
        {
            if (monstersQuery.Drop != null && !AlphaNumericUnderscoreHyphenValidator.IsValid(monstersQuery.Drop))
            {
                throw new InvalidQueryParameter(nameof(monstersQuery.Drop), "Allowed values include letters (a-z, A-Z), digits (0-9), underscores (_), and hyphens (-), with no spaces or special characters.");
            }

            if (monstersQuery.MaxLevel.HasValue && monstersQuery.MaxLevel.Value < 0)
            {
                throw new InvalidQueryParameter(nameof(monstersQuery.MaxLevel), ">=0");
            }

            if (monstersQuery.MinLevel.HasValue && monstersQuery.MinLevel.Value < 0)
            {
                throw new InvalidQueryParameter(nameof(monstersQuery.MinLevel), ">=0");
            }
        }
    }
}
