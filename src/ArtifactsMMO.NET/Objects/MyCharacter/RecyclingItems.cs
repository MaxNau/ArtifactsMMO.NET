using ArtifactsMMO.NET.Objects.Items;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyCharacter
{
    /// <summary>
    /// Recycling items details
    /// </summary>
    public class RecyclingItems
    {
        internal RecyclingItems() { }

        [JsonConstructor]
        internal RecyclingItems(IReadOnlyCollection<SimpleItem> items)
        {
            Items = items;
        }

        /// <summary>
        /// Recycled items
        /// </summary>
        public IReadOnlyCollection<SimpleItem> Items { get; }
    }
}
