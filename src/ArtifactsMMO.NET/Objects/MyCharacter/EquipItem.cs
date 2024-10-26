using ArtifactsMMO.NET.Objects.Characters;
using ArtifactsMMO.NET.Objects.Items;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyCharacter
{
    /// <summary>
    /// Represents the data related to a character's equip/unequip action.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="ActionData"/>.
    /// </remarks>
    public class EquipItem : ActionData
    {
        internal EquipItem() { }

        [JsonConstructor]
        internal EquipItem(Cooldown cooldown, string slot, Item item, Character character)
            : base(cooldown, character)
        {
            Slot = slot;
            Item = item;
        }

        /// <summary>
        /// Item slot.
        /// </summary>
        public string Slot { get; }

        /// <summary>
        /// Item details.
        /// </summary>
        public Item Item { get; }
    }
}
