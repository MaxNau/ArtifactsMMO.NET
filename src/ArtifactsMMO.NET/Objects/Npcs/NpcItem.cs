using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Npcs
{
    /// <summary>
    /// Npc item details
    /// </summary>
    public class NpcItem
    {
        internal NpcItem() { }

        [JsonConstructor]
        internal NpcItem(string code, string npc, int buyPrice, int? sellPrice)
        {
            Code = code;
            Npc = npc;
            BuyPrice = buyPrice;
            SellPrice = sellPrice;
        }

        /// <summary>
        /// The code of the NPC. This is the NPC's unique identifier (ID).
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Code of the NPC that sells/buys the item.
        /// </summary>
        public string Npc { get; }

        /// <summary>
        /// Price to buy the item.
        /// </summary>
        public int BuyPrice { get; }

        /// <summary>
        /// Price to sell the item.
        /// </summary>
        public int? SellPrice { get; }
    }
}
