using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Queries;
using ArtifactsMMO.NET.Validators.Static;

namespace ArtifactsMMO.NET.Validators
{
    internal class BankItemsQueryValidator : IValidator<BankItemsQuery>
    {
        public void Validate(BankItemsQuery bankItemsQuery)
        {
            if (bankItemsQuery.ItemCode != null && !AlphaNumericUnderscoreHyphenValidator.IsValid(bankItemsQuery.ItemCode))
            {
                throw new InvalidQueryParameter(nameof(bankItemsQuery.ItemCode), "Allowed values include letters (a-z, A-Z), digits (0-9), underscores (_), and hyphens (-), with no spaces or special characters.");
            }
        }
    }
}
