using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Queries;
using ArtifactsMMO.NET.Validators.Static;

namespace ArtifactsMMO.NET.Validators
{
    internal class MapsQueryValidator : IValidator<MapsQuery>
    {
        public void Validate(MapsQuery mapsQuery)
        {
            if (mapsQuery.ContentCode != null && !AlphaNumericUnderscoreHyphenValidator.IsValid(mapsQuery.ContentCode))
            {
                throw new InvalidQueryParameter(nameof(mapsQuery.ContentCode), "Allowed values include letters (a-z, A-Z), digits (0-9), underscores (_), and hyphens (-), with no spaces or special characters.");
            }
        }
    }
}
