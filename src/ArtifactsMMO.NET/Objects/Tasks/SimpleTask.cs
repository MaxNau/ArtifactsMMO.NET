using ArtifactsMMO.NET.Enums;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.Tasks
{
    /// <summary>
    /// Task brief details
    /// </summary>
    public class SimpleTask
    {
        internal SimpleTask() { }

        [JsonConstructor]
        internal SimpleTask(string code, TaskType type, int total)
        {
            Code = code;
            Type = type;
            Total = total;
        }

        /// <summary>
        /// Task objective.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// The type of task.
        /// </summary>
        public TaskType Type { get; }

        /// <summary>
        /// The total required to complete the task.
        /// </summary>
        public int Total { get; }
    }
}
