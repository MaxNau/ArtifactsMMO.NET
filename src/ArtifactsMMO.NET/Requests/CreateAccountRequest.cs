using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Validators;

namespace ArtifactsMMO.NET.Requests
{
    /// <summary>
    /// Represents a request to create a new account.
    /// </summary>
    /// <remarks>
    /// This class encapsulates the necessary information required to create a new user account, 
    /// including the username, password, and email address.
    /// </remarks>
    public class CreateAccountRequest : IRequest
    {
        private static readonly IValidator<CreateAccountRequest> _validator = new CreateAccountRequestValidator();

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAccountRequest"/> class.
        /// </summary>
        /// <param name="username">The desired username for the new account.</param>
        /// <param name="password">The password for the new account.</param>
        /// <param name="email">The email address associated with the account.</param>
        /// <exception cref="InvalidRequestParameter"></exception>
        public CreateAccountRequest(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
            
            _validator.Validate(this);
        }

        /// <summary>
        /// Gets the desired username for the new account.
        /// </summary>
        public string Username { get; }

        /// <summary>
        /// Gets the password for the new account.
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// Gets the email address associated with the account.
        /// </summary>
        public string Email { get; }
    }
}
