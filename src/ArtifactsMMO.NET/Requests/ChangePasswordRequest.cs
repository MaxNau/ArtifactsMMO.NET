using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Validators;
using System;

namespace ArtifactsMMO.NET.Requests
{
    /// <summary>
    /// Request to change the password.
    /// </summary>
    public class ChangePasswordRequest : IRequest
    {
        private static readonly IValidator<ChangePasswordRequest> _validator = new ChangePasswordRequestValidator();

        /// <summary>
        /// Initializes a new instance of the <see cref="CraftingRequest"/> class.
        /// </summary>
        /// <param name="currentPassword">Current password.</param>
        /// <param name="newPassword">New password.</param>
        /// <exception cref="ArgumentException">Thrown when <paramref name="currentPassword"/> or
        /// <paramref name="newPassword"/> contains not allowed characters. Should match pattern ^[^\s]+$</exception>
        /// <exception cref="MustNotUseCurrentPassword"></exception>
        public ChangePasswordRequest(string currentPassword, string newPassword)
        {
            CurrentPassword = currentPassword;
            NewPassword = newPassword;

            _validator.Validate(this);
        }

        /// <summary>
        /// Current password
        /// </summary>
        public string CurrentPassword { get; }

        /// <summary>
        /// New password
        /// </summary>
        public string NewPassword { get; }
    }
}
