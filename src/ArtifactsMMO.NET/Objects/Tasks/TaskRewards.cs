using ArtifactsMMO.NET.Objects.Items;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Tasks
{
    /// <summary>
    /// Task rewards details
    /// </summary>
    public class TaskRewards
    {
        internal TaskRewards() { }

        [JsonConstructor]
        internal TaskRewards(IReadOnlyCollection<SimpleItem> items, int gold)
        {
            Items = items;
            Gold = gold;
        }

        /// <summary>
        /// Items rewards.
        /// </summary>
        public IReadOnlyCollection<SimpleItem> Items { get; }

        /// <summary>
        /// Gold rewards.
        /// </summary>
        public int Gold { get; }
    }
}
