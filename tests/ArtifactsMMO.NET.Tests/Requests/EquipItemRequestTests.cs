using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Requests;


namespace ArtifactsMMO.NET.Tests.Requests
{
    public class EquipItemRequestTests
    {
        [Fact]
        public void Constructor_ValidParameters_CreatesInstance()
        {
            var validCode = "validItemCode";
            var slot = ItemSlot.Boots;
            int? quantity = 1;

            var request = new EquipItemRequest(validCode, slot, quantity);

            Assert.Equal(validCode, request.Code);
            Assert.Equal(slot, request.Slot);
            Assert.Equal(quantity, request.Quantity);
        }

        [Fact]
        public void Constructor_InvalidCode_ThrowsItemCodeHasDisallowedCharacters()
        {
            var invalidCode = "invalid item code!";
            var slot = ItemSlot.Weapon;

            Assert.Throws<ItemCodeHasDisallowedCharacters>(() => new EquipItemRequest(invalidCode, slot));
        }

        [Fact]
        public void Constructor_DisallowedConsumablesQuantity_ThrowsDisallowedConsumablesQuantity()
        {
            var validCode = "validItemCode";
            var slot = ItemSlot.Utility1;
            int? quantity = 200;

            Assert.Throws<DisallowedConsumablesQuantity>(() => new EquipItemRequest(validCode, slot, quantity));
        }

        [Fact]
        public void Constructor_DisallowedItemQuantity_ThrowsDisallowedItemQuantity()
        {
            var validCode = "validItemCode";
            var slot = ItemSlot.Amulet;
            int? quantity = 5;

            Assert.Throws<DisallowedItemQuantity>(() => new EquipItemRequest(validCode, slot, quantity));
        }

        [Fact]
        public void Constructor_ValidConsumableParameters_CreatesInstance()
        {
            var validCode = "validConsumableCode";
            var slot = ItemSlot.Utility1;
            int? quantity = 10;

            var request = new EquipItemRequest(validCode, slot, quantity);

            Assert.Equal(validCode, request.Code);
            Assert.Equal(slot, request.Slot);
            Assert.Equal(quantity, request.Quantity);
        }

        [Fact]
        public void Constructor_ValidEquipmentParameters_CreatesInstance()
        {
            var validCode = "validEquipmentCode";
            var slot = ItemSlot.Weapon;
            int? quantity = 1;

            var request = new EquipItemRequest(validCode, slot, quantity);

            Assert.Equal(validCode, request.Code);
            Assert.Equal(slot, request.Slot);
            Assert.Equal(quantity, request.Quantity);
        }

        [Fact]
        public void Constructor_ValidEquipmentParameters_WhenNoQuantityProvided_CreatesInstance()
        {
            var validCode = "validEquipmentCode";
            var slot = ItemSlot.Weapon;

            var request = new EquipItemRequest(validCode, slot);

            Assert.Equal(validCode, request.Code);
            Assert.Equal(slot, request.Slot);
            Assert.Null(request.Quantity);
        }
    }
}
