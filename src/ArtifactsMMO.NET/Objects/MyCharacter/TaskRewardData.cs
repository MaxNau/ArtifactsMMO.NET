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
        internal TaskRewardData(TaskRewards rewards, Cooldown cooldown, Character character)
            : base(cooldown, character)
        {
            Rewards = rewards;
        }

        /// <summary>
        /// Reward details.
        /// </summary>
        public TaskRewards Rewards { get; }
    }
}
