using System;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.GrandExchange
{
    /// <summary>
    /// Grand Exchange historical order details
    /// </summary>
    public class GrandExchangeOrderHistory
    {
        internal GrandExchangeOrderHistory() { }

        [JsonConstructor]
        internal GrandExchangeOrderHistory(string id, string seller, string buyer, string code, int quantity,
            int price, DateTimeOffset soldAt)
        {
            Id = id;
            Seller = seller;
            Buyer = buyer;
            Code = code;
            Quantity = quantity;
            Price = price;
            SoldAt = soldAt;
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
        /// Buyer account name.
        /// </summary>
        public string Buyer { get; }

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
        /// Sale datetime.
        /// </summary>
        public DateTimeOffset SoldAt { get; }
    }
}
