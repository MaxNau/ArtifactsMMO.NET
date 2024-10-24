using System;

namespace ArtifactsMMO.NET.Validators
{
    internal class PasswordFormatValidator : IValidator<string>
    {
        public void Validate(string value)
        {
            if (value.Length < 5 || value.Length > 50)
            {
                throw new ArgumentException("Password must be between 5 and 50 characters long.");
            }

            foreach (char c in value)
            {
                if (char.IsWhiteSpace(c))
                {
                    throw new ArgumentException("Password must not contain whitespace characters.");
                }
            }
        }
    }
}
