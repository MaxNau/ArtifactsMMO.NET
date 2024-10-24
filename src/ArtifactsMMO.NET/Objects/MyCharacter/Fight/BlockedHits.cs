using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyCharacter.Fight
{
    /// <summary>
    /// Blocked hits details
    /// </summary>
    public class BlockedHits
    {
        internal BlockedHits() { }

        [JsonConstructor]
        internal BlockedHits(int fire, int earth, int water, int air, int total)
        {
            Fire = fire;
            Earth = earth;
            Water = water;
            Air = air;
            Total = total;
        }

        /// <summary>
        /// The amount of fire hits blocked.
        /// </summary>
        public int Fire { get; }

        /// <summary>
        /// The amount of earth hits blocked.
        /// </summary>
        public int Earth { get; }

        /// <summary>
        /// The amount of water hits blocked.
        /// </summary>
        public int Water { get; }

        /// <summary>
        /// The amount of air hits blocked.
        /// </summary>
        public int Air { get; }

        /// <summary>
        /// The amount of total hits blocked.
        /// </summary>
        public int Total { get; }
    }
}
