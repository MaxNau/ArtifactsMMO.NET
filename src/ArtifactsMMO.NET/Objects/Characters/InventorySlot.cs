using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Characters
{
    /// <summary>
    /// Inventory slot details
    /// </summary>
    public class InventorySlot
    {
        internal InventorySlot() { }

        [JsonConstructor]
        internal InventorySlot(int slot, string code, int quantity)
        {
            Slot = slot;
            Code = code;
            Quantity = quantity;
        }

        /// <summary>
        /// Inventory slot identifier.
        /// </summary>
        public int Slot { get; }

        /// <summary>
        /// Item code.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Quantity in the slot.
        /// </summary>
        public int Quantity { get; }
    }
}
