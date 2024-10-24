namespace ArtifactsMMO.NET.Validators.Static
{
    internal static class AlphaNumericUnderscoreHyphenValidator
    {
        internal static bool IsValid(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            foreach (char c in input)
            {
                if (!char.IsLetterOrDigit(c) && c != '_' && c != '-')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
