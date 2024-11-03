using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Requests;
using ArtifactsMMO.NET.Validators.Static;
using System;
using System.Linq;

namespace ArtifactsMMO.NET.Validators
{
    internal class CreateAccountRequestValidator : IValidator<CreateAccountRequest>
    {
        public void Validate(CreateAccountRequest createAccountRequest)
        {
            if (createAccountRequest.Username.Length < 6 || createAccountRequest.Username.Length > 32)
            {
                throw new InvalidRequestParameter(nameof(createAccountRequest.Username), "Username must be between 6 and 32 characters long.");
            }

            if (!AlphaNumericUnderscoreHyphenValidator.IsValid(createAccountRequest.Username))
            {
                throw new InvalidRequestParameter(nameof(createAccountRequest.Username), "Username must conatin only letters (A-Z, a-z), numbers (0-9), underscores (_), and hyphens (-).");
            }

            if (createAccountRequest.Password.Length < 5 || createAccountRequest.Password.Length > 50)
            {
                throw new InvalidRequestParameter(nameof(createAccountRequest.Username), "Password must be between 5 and 50 characters long.");
            }

            if (createAccountRequest.Password.Any(char.IsWhiteSpace))
            {
                throw new ArgumentException("Password must not contain whitespace characters.");
            }
        }
    }
}
