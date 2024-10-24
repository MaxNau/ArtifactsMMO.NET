using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Queries;
using ArtifactsMMO.NET.Validators.Static;

namespace ArtifactsMMO.NET.Validators
{
    internal class ItemsQueryValidator : IValidator<ItemsQuery>
    {
        public void Validate(ItemsQuery itemsQuery)
        {
            if (!AlphaNumericUnderscoreHyphenValidator.IsValid(itemsQuery.CraftMaterial))
            {
                throw new InvalidQueryParameter(nameof(itemsQuery.CraftMaterial), "Allowed values include letters (a-z, A-Z), digits (0-9), underscores (_), and hyphens (-), with no spaces or special characters.");
            }

            if (!AlphaNumericUnderscoreHyphenValidator.IsValid(itemsQuery.Name))
            {
                throw new InvalidQueryParameter(nameof(itemsQuery.Name), "Allowed values include letters (a-z, A-Z), digits (0-9), underscores (_), and hyphens (-), with no spaces or special characters.");
            }

            if (itemsQuery.MaxLevel.HasValue && itemsQuery.MaxLevel.Value < 0)
            {
                throw new InvalidQueryParameter(nameof(itemsQuery.MaxLevel), ">=0");
            }

            if (itemsQuery.MinLevel.HasValue && itemsQuery.MinLevel.Value < 0)
            {
                throw new InvalidQueryParameter(nameof(itemsQuery.MinLevel), ">=0");
            }
        }
    }
}
