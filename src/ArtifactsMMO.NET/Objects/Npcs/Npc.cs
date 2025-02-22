using ArtifactsMMO.NET.Enums;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Npcs
{
    /// <summary>
    /// Npc details
    /// </summary>
    public class Npc
    {
        internal Npc() { }

        [JsonConstructor]
        internal Npc(string name, string code, string description, NpcType type)
        {
            Name = name;
            Code = code;
            Description = description;
            Type = type;
        }

        /// <summary>
        /// Name of the NPC.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The code of the NPC. This is the NPC's unique identifier (ID).
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Description of the NPC.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Type of the NPC.
        /// </summary>
        public NpcType Type {get;}
    }
}
