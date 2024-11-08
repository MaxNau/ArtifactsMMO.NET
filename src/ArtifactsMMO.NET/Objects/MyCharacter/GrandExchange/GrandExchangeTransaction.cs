using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyCharacter.GrandExchange
{
    /// <summary>
    /// Grand Exchange transaction details
    /// </summary>
    public class GrandExchangeTransaction
    {
        internal GrandExchangeTransaction() { }

        [JsonConstructor]
        internal GrandExchangeTransaction(string id, string code, int quantity, int price, int totalPrice)
        {
            Id = id;
            Code = code;
            Quantity = quantity;
            Price = price;
            TotalPrice = totalPrice;
        }

        /// <summary>
        /// Order id.
        /// </summary>
        public string Id { get; }

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
