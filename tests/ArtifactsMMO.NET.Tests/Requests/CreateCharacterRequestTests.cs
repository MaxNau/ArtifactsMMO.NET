using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Requests;

namespace ArtifactsMMO.NET.Tests.Requests
{
    public class CreateCharacterRequestTests
    {
        [Fact]
        public void Constructor_ShouldCreateInstance_WhenValidParametersAreProvided()
        {
            string validName = "ValidName";
            SkinCode validSkin = SkinCode.Women1;

            var request = new CreateCharacterRequest(validName, validSkin);

            Assert.NotNull(request);
            Assert.Equal(validName, request.Name);
            Assert.Equal(validSkin, request.Skin);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("Invalid@Input!")]
        [InlineData("Invalid#Input$")]
        public void Constructor_ShouldThrowCharacterNameHasDisallowedCharacters_WhenNameContainsInvalidCharacters(string input)
        {
            string invalidName = input;

            Assert.Throws<CharacterNameHasDisallowedCharacters>(() => new CreateCharacterRequest(invalidName, SkinCode.Men1));
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentException_WhenNameIsTooShort()
        {
            string shortName = "A";

            Assert.Throws<ArgumentException>(() => new CreateCharacterRequest(shortName, SkinCode.Women1));
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentException_WhenNameIsTooLong()
        {
            string longName = new string('A', 13);

            Assert.Throws<ArgumentException>(() => new CreateCharacterRequest(longName, SkinCode.Men1));
        }
    }
}
