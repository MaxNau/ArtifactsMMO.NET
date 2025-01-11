using ArtifactsMMO.NET.Objects.Notifications;
using ArtifactsMMO.NET.WebSockets;
using System.Collections.Generic;

namespace ArtifactsMMO.NET.Endpoints.Notifications.MessageFactory
{
    internal class NotificationMessageFactoryFactory : MessageFactoryFactory<ServerNotification>
    {
        protected override IEnumerable<IMessageFactory<ServerNotification>> GetFactories()
        {
            return new IMessageFactory<ServerNotification>[]
            {
                new EventSpawnMessageFactory(),
                new EventRemovedMessageFactory(),
                new GrandExchangeNewOrderMessageFactory(),
                new GrandExchangeSellMessageFactory(),
                new AchievementUnlockMessageFactory(),
                new TestSpawnMessageFactory()
            };
        }
    }
}
