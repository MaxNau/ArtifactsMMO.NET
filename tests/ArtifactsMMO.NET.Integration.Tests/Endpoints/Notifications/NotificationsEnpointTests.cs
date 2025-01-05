using ArtifactsMMO.NET.Endpoints.Notifications;
using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Requests;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Priority;

namespace ArtifactsMMO.NET.Integration.Tests.Endpoints.MyCharacters
{
    public class NotificationsEnpointTests : IClassFixture<TestFixture>
    {
        private readonly IArtifactsMMOClient _client;
        private readonly IConfiguration _configuration;


        public NotificationsEnpointTests(TestFixture fixture)
        {
            _client = fixture.ServiceProvider.GetRequiredService<IArtifactsMMOClient>();
            _configuration = fixture.Configuration;

        }

        [Fact, Priority(1)]
        public async Task OpenNotificationChannelShouldWork()
        {
            NotificationSubscription openNotificationChannelAsync = await _client.Notifications.OpenNotificationChannelAsync(new OpenNotificationsChannelRequest(NotificationType.Test));
            try
            {
                //Arrange
                openNotificationChannelAsync.NewNotification += OpenNotificationChannelAsync_OnNewNotification;
                bool testReceived = false;
                void OpenNotificationChannelAsync_OnNewNotification(object? sender, NotificationSubscriptionNewNotificationEventArgs e)
                {
                    if (e.Notification.Type == NotificationType.Test)
                    {                                        
                        testReceived = true;
                    }
                }

                //Act(wait for the 60 sec from the server, this is a long test, but since it's coming from the artifactmmo server
                await Task.Delay(TimeSpan.FromSeconds(60+10));//10 to allow some debug time

                //Assert
                Assert.True(testReceived);


            }
            finally
            {
                openNotificationChannelAsync.Dispose();
            }
        }

    }
}
