using System;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyCharacter.GrandExchange
{
    /// <summary>
    /// Represents the details of an order that has been created.
    /// </summary>
    public class GrandExchangeOrderCreated
    {
        internal GrandExchangeOrderCreated() { }

        [JsonConstructor]
        internal GrandExchangeOrderCreated(string id, DateTime createdAt, string code, int quantity,
            int price, int totalPrice, int tax)
        {
            Id = id;
            CreatedAt = createdAt;
            Code = code;
            Quantity = quantity;
            Price = price;
            TotalPrice = totalPrice;
            Tax = tax;
        }

        /// <summary>
        /// Order ID.
        /// </summary>
        public string Id { get; }


        /// <summary>
        /// Date and time when the order was created.
        /// </summary>
        public DateTime CreatedAt { get; }


        /// <summary>
        /// Item code for the ordered item.
        /// </summary>
        public string Code { get; }


        /// <summary>
        /// Quantity of the item ordered.
        /// </summary>
        public int Quantity { get; }

        /// <summary>
        /// Price per unit of the item ordered.
        /// </summary>
        public int Price { get; }

        /// <summary>
        /// Total price for the order.
        /// </summary>
        public int TotalPrice { get; }

        /// <summary>
        /// Tax applied to the order.
        /// It is 5% of the total price, with a minimum of 1.
        /// </summary>
        public int Tax { get; }
    }
}
