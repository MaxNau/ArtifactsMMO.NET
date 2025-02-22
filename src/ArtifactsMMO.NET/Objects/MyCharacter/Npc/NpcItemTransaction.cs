using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyCharacter.Npc
{
    /// <summary>
    /// NpcItemTransaction details
    /// </summary>
    /// <remarks>
    /// </remarks>
    public class NpcItemTransaction
    {
        internal NpcItemTransaction() { }

        [JsonConstructor]
        internal NpcItemTransaction(string code, int quantity, int price, int totalPrice)
        {
            Code = code;
            Quantity = quantity;
            Price = price;
            TotalPrice = totalPrice;
        }

        /// <summary>
        /// Item code.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Item quantity.
        /// </summary>
        public int Quantity { get; }

        /// <summary>
        /// Item price.
        /// </summary>
        public int Price { get; }

        /// <summary>
        /// Total price of the transaction.
        /// </summary>
        public int TotalPrice { get; }
    }
}
