using ArtifactsMMO.NET.Endpoints.Notifications.MessageFactory;
using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Objects.Notifications;
using ArtifactsMMO.NET.WebSockets;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using Task = System.Threading.Tasks.Task;

namespace ArtifactsMMO.NET.Endpoints.Notifications
{
    /// <summary>
    /// Represent a notification endpoint
    /// </summary>
    public class NotificationSubscription : RealTimeSubscription<ServerNotification>
    {
        private readonly IEnumerable<NotificationType> _notificationTypes;
        private readonly string _token;

        /// <summary>
        /// Events coming from the servers will be received here
        /// </summary>
        public event EventHandler<NotificationSubscriptionNewNotificationEventArgs> NewNotification;

        internal NotificationSubscription(Uri address, string token, IEnumerable<NotificationType> notificationTypes, JsonSerializerOptions jsonSerializerOptions, NotificationMessageFactoryFactory messageFactoryFactory) 
            : base(address, jsonSerializerOptions, messageFactoryFactory)
        {
            _token = token;
            _notificationTypes = notificationTypes;
        }

        internal override async Task Start(CancellationToken cancellationToken)
        {
            await base.Start(cancellationToken);
            await SendNotificationTypes(_token, _notificationTypes);
        }

        private async Task SendNotificationTypes(string token, IEnumerable<NotificationType> notificationTypes)
        {
            await SendMessageAsync(new StartNotifications(token, notificationTypes));
        }

        /// <inheritdoc />
        protected override void HandleMessageReceived(ServerNotification message)
        {
            NewNotification?.Invoke(this, new NotificationSubscriptionNewNotificationEventArgs(message));
        }
    }
}
