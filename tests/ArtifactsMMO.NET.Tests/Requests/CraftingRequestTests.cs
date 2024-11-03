using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Requests;

namespace ArtifactsMMO.NET.Tests.Requests
{
    public class CraftingRequestTests
    {
        [Fact]
        public void Constructor_ShouldCreateInstance_WhenValidParametersAreProvided()
        {
            string validCode = "Item_123";
            int? validQuantity = 5;

            var request = new CraftingRequest(validCode, validQuantity);

            Assert.NotNull(request);
            Assert.Equal(validCode, request.Code);
            Assert.Equal(validQuantity, request.Quantity);
        }

        [Fact]
        public void Constructor_ShouldThrowItemCodeHasDisallowedCharacters_WhenCodeContainsInvalidCharacters()
        {
            string invalidCode = "Item@123";
            Assert.Throws<ItemCodeHasDisallowedCharacters>(() => new CraftingRequest(invalidCode));
        }

        [Fact]
        public void Constructor_ShouldThrowDisallowedQuantity_WhenQuantityIsLessThanOne()
        {
            string validCode = "Item_789";
            int invalidQuantity = 0;

            Assert.Throws<DisallowedQuantity>(() => new CraftingRequest(validCode, invalidQuantity));
        }
    }
}
