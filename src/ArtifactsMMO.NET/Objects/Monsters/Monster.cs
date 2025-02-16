using System.Collections.Generic;
using System.Text.Json.Serialization;
using ArtifactsMMO.NET.Objects.Effects;
using ArtifactsMMO.NET.Objects.Loot;

namespace ArtifactsMMO.NET.Objects.Monsters
{
    /// <summary>
    /// Monster details
    /// </summary>
    public class Monster
    {
        internal Monster() { }

        [JsonConstructor]
        internal Monster(string name, string code, long level, long hp, long attackFire, long attackEarth,
            long attackWater, long attackAir, long resFire, long resEarth, long resWater, long resAir,
            int criticalStrike, IReadOnlyCollection<SimpleEffect> effects,
            long minGold, long maxGold, IReadOnlyCollection<DropDetails> drops)
        {
            Name = name;
            Code = code;
            Level = level;
            Hp = hp;
            AttackFire = attackFire;
            AttackEarth = attackEarth;
            AttackWater = attackWater;
            AttackAir = attackAir;
            ResFire = resFire;
            ResEarth = resEarth;
            ResWater = resWater;
            ResAir = resAir;
            CriticalStrike = criticalStrike;
            Effects = effects;
            MinGold = minGold;
            MaxGold = maxGold;
            Drops = drops;
        }

        /// <summary>
        /// Name of the monster.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The code of the monster. This is the monster's unique identifier (ID).
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Monster level.
        /// </summary>
        public long Level { get; }

        /// <summary>
        /// Monster hit points.
        /// </summary>
        public long Hp { get; }

        /// <summary>
        /// Monster fire attack.
        /// </summary>
        public long AttackFire { get; }

        /// <summary>
        /// Monster earth attack.
        /// </summary>
        public long AttackEarth { get; }

        /// <summary>
        /// Monster water attack.
        /// </summary>
        public long AttackWater { get; }

        /// <summary>
        /// Monster air attack.
        /// </summary>
        public long AttackAir { get; }

        /// <summary>
        /// Monster % fire resistance.
        /// </summary>
        public long ResFire { get; }

        /// <summary>
        /// Monster % earth resistance.
        /// </summary>
        public long ResEarth { get; }

        /// <summary>
        /// Monster % water resistance.
        /// </summary>
        public long ResWater { get; }

        /// <summary>
        /// Monster % air resistance.
        /// </summary>
        public long ResAir { get; }

        /// <summary>
        /// Monster % critical strike.
        /// </summary>
        public int CriticalStrike { get; }

        /// <summary>
        /// List of effects.
        /// </summary>
        public IReadOnlyCollection<SimpleEffect> Effects { get; }

        /// <summary>
        /// Monster minimum gold drop.
        /// </summary>
        public long MinGold { get; }

        /// <summary>
        /// Monster maximum gold drop.
        /// </summary>
        public long MaxGold { get; }

        /// <summary>
        /// Monster drops. This is a list of items that the monster drops after killing the monster.
        /// </summary>
        public IReadOnlyCollection<DropDetails> Drops { get; }
    }
}
