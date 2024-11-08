using System;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.GrandExchange
{
    /// <summary>
    /// Grand Exchange sell order details
    /// </summary>
    public class GrandExchangeOrder
    {
        internal GrandExchangeOrder() { }

        [JsonConstructor]
        internal GrandExchangeOrder(string id, string seller, string code, int quantity, int price,
            DateTimeOffset createdAt)
        {
            Id = id;
            Seller = seller;
            Code = code;
            Quantity = quantity;
            Price = price;
            CreatedAt = createdAt;
        }

        /// <summary>
        /// Order id.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Seller account name.
        /// </summary>
        public string Seller { get; }

        /// <summary>
        /// Item code.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Item quantity.
        /// </summary>
        public int Quantity { get; }

        /// <summary>
        /// Item price per unit.
        /// </summary>
        public int Price { get; }

        /// <summary>
        /// Order created at.
        /// </summary>
        DateTimeOffset CreatedAt { get; }
    }
}
