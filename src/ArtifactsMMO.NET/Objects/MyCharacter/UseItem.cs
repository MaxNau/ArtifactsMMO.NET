using ArtifactsMMO.NET.Objects.Characters;
using ArtifactsMMO.NET.Objects.Items;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyCharacter
{
    /// <summary>
    /// Represents the data related to a character's use item action.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="ActionData"/>.
    /// </remarks>
    public class UseItem : ActionData
    {
        internal UseItem() { }

        [JsonConstructor]
        internal UseItem(Item item, Cooldown cooldown, Character character) : base(cooldown, character)
        {
            Item = item;
        }

        /// <summary>
        /// Item details.
        /// </summary>
        public Item Item { get; }
    }
}
