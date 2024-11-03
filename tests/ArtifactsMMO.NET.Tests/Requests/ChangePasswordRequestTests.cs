using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Requests;
using ArtifactsMMO.NET.Validators;

namespace ArtifactsMMO.NET.Tests.Validators
{
    public class ChangePasswordRequestTests
    {
        private readonly ChangePasswordRequestValidator _validator;

        public ChangePasswordRequestTests()
        {
            _validator = new ChangePasswordRequestValidator();
        }

        [Theory]
        [InlineData("", "ValidNewPassword", "Current password must not be empty.")]
        [InlineData("ValidCurrentPassword", "", "New password must not be empty.")]
        [InlineData("123", "123", "Current password must be between 5 and 50 characters long.")]
        [InlineData("ValidCurrentPassword", "New Invalid", "Password must not contain whitespace characters.")]
        public void Validate_ShouldThrowArgumentException_WhenInvalidPasswords(string currentPassword, string newPassword, string expectedMessage)
        {
            var ex = Assert.Throws<ArgumentException>(() => new ChangePasswordRequest(currentPassword, newPassword));
            Assert.Equal(expectedMessage, ex.Message);
        }

        [Fact]
        public void Validate_ShouldThrowMustNotUseCurrentPassword_WhenNewPasswordIsSameAsCurrentPassword()
        {
            var ex = Assert.Throws<MustNotUseCurrentPassword>(() => new ChangePasswordRequest("Valid123!", "Valid123!"));
            Assert.Equal("New password must not be the same as current password.", ex.Message);
        }

        [Fact]
        public void Constructor_ShouldCreateInstance_WhenValidPasswordsAreProvided()
        {
            string currentPassword = "MyP@ssw0rd";
            string newPassword = "NewP@ssw0rd";

            var request = new ChangePasswordRequest(currentPassword, newPassword);

            Assert.NotNull(request);
            Assert.Equal(currentPassword, request.CurrentPassword);
            Assert.Equal(newPassword, request.NewPassword);
        }
    }
}
