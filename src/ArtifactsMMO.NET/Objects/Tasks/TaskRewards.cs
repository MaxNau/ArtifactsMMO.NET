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
        internal TaskRewards(IReadOnlyCollection<SimpleItem> items)
        {
            Items = items;
        }

        /// <summary>
        /// Rewards
        /// </summary>
        public IReadOnlyCollection<SimpleItem> Items { get; }
    }
}
