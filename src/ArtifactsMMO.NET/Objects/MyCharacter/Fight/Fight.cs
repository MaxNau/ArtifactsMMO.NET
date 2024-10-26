using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Objects.Loot;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyCharacter.Fight
{
    /// <summary>
    /// Fight details.
    /// </summary>
    public class Fight
    {
        internal Fight() { }

        [JsonConstructor]
        internal Fight(int xp, int gold, IReadOnlyCollection<Drop> drops, int turns,
            BlockedHits monsterBlockedHits, BlockedHits playerBlockedHits, IReadOnlyCollection<string> logs,
            FightResult result)
        {
            Xp = xp;
            Gold = gold;
            Drops = drops;
            Turns = turns;
            MonsterBlockedHits = monsterBlockedHits;
            PlayerBlockedHits = playerBlockedHits;
            Logs = logs;
            Result = result;
        }

        /// <summary>
        /// The amount of xp gained by the fight.
        /// </summary>
        public int Xp { get; }

        /// <summary>
        /// The amount of gold gained by the fight.
        /// </summary>
        public int Gold { get; }

        /// <summary>
        /// The items dropped by the fight.
        /// </summary>
        public IReadOnlyCollection<Drop> Drops { get; }

        /// <summary>
        /// Numbers of the turns of the combat.
        /// </summary>
        public int Turns { get; }

        /// <summary>
        /// The amount of blocked hits by the monster.
        /// </summary>
        public BlockedHits MonsterBlockedHits { get; }

        /// <summary>
        /// The amount of blocked hits by the player.
        /// </summary>
        public BlockedHits PlayerBlockedHits { get; }

        /// <summary>
        /// The fight logs.
        /// </summary>
        public IReadOnlyCollection<string> Logs { get; }

        /// <summary>
        /// The result of the fight.
        /// </summary>
        public FightResult Result { get; }
    }
}
