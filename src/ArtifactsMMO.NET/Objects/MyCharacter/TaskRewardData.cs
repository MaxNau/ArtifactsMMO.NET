using ArtifactsMMO.NET.Objects.Characters;
using ArtifactsMMO.NET.Objects.Tasks;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyCharacter
{
    /// <summary>
    /// Task reward data associated with complete and task exchange actions
    /// </summary>
    public class TaskRewardData : ActionData
    {
        internal TaskRewardData() { }

        [JsonConstructor]
        internal TaskRewardData(SimpleTaskReward reward, Cooldown cooldown, Character character)
            : base(cooldown, character)
        {
            Reward = reward;
        }

        /// <summary>
        /// Brief task reward details
        /// </summary>
        public SimpleTaskReward Reward { get; }
    }
}
