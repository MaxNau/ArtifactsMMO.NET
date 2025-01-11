using ArtifactsMMO.NET.Endpoints.Notifications.MessageFactory;
using ArtifactsMMO.NET.Internal;
using ArtifactsMMO.NET.Requests;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ArtifactsMMO.NET.Endpoints.Notifications
{
    internal class Notifications : INotifications
    {
        private const string URL = "wss://realtime.artifactsmmo.com";
        private readonly string _apiKey;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly NotificationMessageFactoryFactory _notificationMessageFactoryFactory;

        internal Notifications(string apiKey)
        {
            _jsonSerializerOptions = new JsonSerializerOptionsFactory().Get(JsonSerializerOptionsMode.Default);
            _notificationMessageFactoryFactory = new NotificationMessageFactoryFactory();
            _apiKey = apiKey;
        }

        public Notifications(string apiKey, IJsonSerializerOptionsFactory jsonSerializerOptionsFactory) : this(apiKey)
        {
            _jsonSerializerOptions = jsonSerializerOptionsFactory.Get(JsonSerializerOptionsMode.Test);
        }

        public async Task<NotificationSubscription> OpenNotificationChannelAsync(OpenNotificationsChannelRequest openNotificationsChannelRequest, CancellationToken? cancellationToken = default)
        {
            NotificationSubscription subscription = new NotificationSubscription(new Uri(URL), _apiKey, openNotificationsChannelRequest.NotificationTypes, _jsonSerializerOptions, _notificationMessageFactoryFactory);
            await subscription.Start(cancellationToken ?? CancellationToken.None);
            return subscription;
        }
    }
}
