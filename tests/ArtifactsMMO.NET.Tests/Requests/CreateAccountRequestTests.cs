using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Requests;

namespace ArtifactsMMO.NET.Tests.Requests
{
    public class CreateAccountRequestTests
    {
        [Fact]
        public void Constructor_ShouldCreateInstance_WhenValidParametersAreProvided()
        {
            string validUsername = "validUser";
            string validPassword = "P@ssword123";
            string validEmail = "user@example.com";

            var request = new CreateAccountRequest(validUsername, validPassword, validEmail);

            Assert.NotNull(request);
            Assert.Equal(validUsername, request.Username);
            Assert.Equal(validPassword, request.Password);
            Assert.Equal(validEmail, request.Email);
        }

        [Fact]
        public void Constructor_ShouldThrowInvalidRequestParameter_WhenUsernameIsInvalid()
        {
            string invalidUsername = ""; // Invalid username (empty)

            Assert.Throws<InvalidRequestParameter>(() => new CreateAccountRequest(invalidUsername, "P@ssword123", "user@example.com"));
        }

        [Fact]
        public void Constructor_ShouldThrowInvalidRequestParameter_WhenPasswordIsInvalid()
        {
            string validUsername = "validUser";
            string invalidPassword = "";

            Assert.Throws<InvalidRequestParameter>(() => new CreateAccountRequest(validUsername, invalidPassword, "user@example.com"));
        }

        [Fact]
        public void Constructor_ShouldThrowInvalidRequestParameter_WhenEmailIsInvalid()
        {
            string validUsername = "validUser";
            string validPassword = "P@ssword123";
            string invalidEmail = "invalidEmail";

            Assert.Throws<InvalidRequestParameter>(() => new CreateAccountRequest(validUsername, validPassword, invalidEmail));
        }
    }
}
