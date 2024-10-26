using ArtifactsMMO.NET.Objects.Characters;
using ArtifactsMMO.NET.Objects.Items;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyCharacter
{
    /// <summary>
    /// Represents the data related to a character's delete item action.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="ActionData"/>.
    /// </remarks>
    public class DeleteItem : ActionData
    {
        internal DeleteItem() { }

        [JsonConstructor]
        internal DeleteItem(SimpleItem item, Cooldown cooldown, Character character)
            : base(cooldown, character)
        {
            Item = item;
        }

        /// <summary>
        /// Deleted item
        /// </summary>
        public SimpleItem Item { get; }
    }
}
