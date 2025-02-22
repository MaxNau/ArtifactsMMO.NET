using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Objects.GrandExchange;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Notifications
{
    /// <summary> 
    /// Notification about a grand exchange sale
    /// </summary>
    public class GrandExchangeSellNotification : ServerNotification
    {
        /// <summary>
        /// The grand exchange sale
        /// </summary>
        public GrandExchangeOrderHistory Data { get; }

        /// <summary>
        /// Construct a new grand exchange sale
        /// </summary>
        /// <param name="type">Notification type</param>
        /// <param name="data">Thew new grand exchange order</param>
        [JsonConstructor]
        public GrandExchangeSellNotification(NotificationType type, GrandExchangeOrderHistory data)
            : base(type)
        {
            Data = data;
        }
    }
}
