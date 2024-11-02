using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Requests;
using System;

namespace ArtifactsMMO.NET.Validators
{
    internal class ChangePasswordRequestValidator : IValidator<ChangePasswordRequest>
    {
        public void Validate(ChangePasswordRequest changePasswordRequest)
        {
            if (string.IsNullOrWhiteSpace(changePasswordRequest.CurrentPassword))
            {
                throw new ArgumentException("Current password must not be empty.");
            }

            if (string.IsNullOrWhiteSpace(changePasswordRequest.NewPassword))
            {
                throw new ArgumentException("New password must not be empty.");
            }

            if (changePasswordRequest.CurrentPassword.Length < 5 ||
                changePasswordRequest.CurrentPassword.Length > 50)
            {
                throw new ArgumentException("Current password must be between 5 and 50 characters long.");
            }
            if (changePasswordRequest.NewPassword.Length < 5 ||
                changePasswordRequest.NewPassword.Length > 50)
            {
                throw new ArgumentException("New password must be between 5 and 50 characters long.");
            }

            ValidatePassword(changePasswordRequest.NewPassword);
            ValidatePassword(changePasswordRequest.CurrentPassword);

            if (changePasswordRequest.CurrentPassword == changePasswordRequest.NewPassword)
            {
                throw new MustNotUseCurrentPassword();
            }
        }

        private void ValidatePassword(string password)
        {
            foreach (char c in password)
            {
                if (char.IsWhiteSpace(c))
                {
                    throw new ArgumentException("Password must not contain whitespace characters.");
                }
            }
        }
    }
}
