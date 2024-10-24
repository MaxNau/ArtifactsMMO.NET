using ArtifactsMMO.NET.Enums;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Tasks
{
    /// <summary>
    /// Task details
    /// </summary>
    public class Task
    {
        internal Task() { }

        [JsonConstructor]
        internal Task(string code, int level, TaskType type, int minQuantity, int maxQuantity, string skill,
            TaskRewards rewards)
        {
            Code = code;
            Level = level;
            Type = type;
            MinQuantity = minQuantity;
            MaxQuantity = maxQuantity;
            Skill = skill;
            Rewards = rewards;
        }

        /// <summary>
        /// Task objective.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Task level.
        /// </summary>
        public int Level { get; }

        /// <summary>
        /// The type of task.
        /// </summary>
        public TaskType Type { get; }

        /// <summary>
        /// Minimum amount of task.
        /// </summary>
        public int MinQuantity { get; }

        /// <summary>
        /// Maximum amount of task.
        /// </summary>
        public int MaxQuantity { get; }

        /// <summary>
        /// Skill required to complete the task.
        /// </summary>
        public string Skill { get; }

        /// <summary>
        /// Rewards.
        /// </summary>
        public TaskRewards Rewards { get; }
    }
}
