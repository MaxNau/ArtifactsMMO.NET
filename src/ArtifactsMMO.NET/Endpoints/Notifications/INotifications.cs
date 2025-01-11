using ArtifactsMMO.NET.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace ArtifactsMMO.NET.Endpoints.Notifications
{
    /// <summary>
    /// Endpoint to open new notifications channels
    /// Notifications through web socket is a feature reserved for founder and subscribers
    /// </summary>
    public interface INotifications
    {
        /// <summary>
        /// Open a new notification channel
        /// </summary>
        /// <param name="openNotificationsChannelRequest">Specifies which notification it should subscribe</param>
        /// <param name="cancellationToken">Allow to terminate the socket</param>
        /// <returns></returns>
        Task<NotificationSubscription> OpenNotificationChannelAsync(OpenNotificationsChannelRequest openNotificationsChannelRequest, CancellationToken? cancellationToken = default);
    }
}
