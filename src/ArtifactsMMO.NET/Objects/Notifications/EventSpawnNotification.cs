using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Objects.Events;

namespace ArtifactsMMO.NET.Objects.Notifications
{
    /// <summary>
    /// Notification about a new event
    /// </summary>
    public class EventSpawnNotification: ServerNotification
    {
        /// <summary>
        /// The active event
        /// </summary>
        public ActiveEvent Data { get; }

        /// <summary>
        /// Construct a new event spawn notification
        /// </summary>
        /// <param name="type">Notification type</param>
        /// <param name="data">Active event</param>
        [JsonConstructor]
        public EventSpawnNotification(NotificationType type, ActiveEvent data )
            : base(type)
        {
            Data = data;
        }
    }
}
