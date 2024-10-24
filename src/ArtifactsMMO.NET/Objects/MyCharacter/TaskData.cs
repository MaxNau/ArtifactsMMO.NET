using ArtifactsMMO.NET.Objects.Characters;
using ArtifactsMMO.NET.Objects.Tasks;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyCharacter
{
    /// <summary>
    /// Task data associated with accept task action
    /// </summary>
    public class TaskData : ActionData
    {
        internal TaskData() { }

        [JsonConstructor]
        internal TaskData(SimpleTask task, Cooldown cooldown, Character character) : base(cooldown, character)
        {
            Task = task;
        }

        /// <summary>
        /// Task brief details
        /// </summary>
        public SimpleTask Task { get; }
    }
}
