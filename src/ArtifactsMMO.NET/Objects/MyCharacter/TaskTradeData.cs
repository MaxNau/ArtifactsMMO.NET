using ArtifactsMMO.NET.Objects.Characters;
using ArtifactsMMO.NET.Objects.Tasks;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects.MyCharacter
{
    /// <summary>
    /// Represents the data related to a task trade action.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="ActionData"/>.
    /// </remarks>
    public class TaskTradeData : ActionData
    {
        internal TaskTradeData() { }

        [JsonConstructor]
        internal TaskTradeData(TaskTrade trade, Cooldown cooldown, Character character)
            : base(cooldown, character)
        {
            Trade = trade;
        }

        /// <summary>
        /// Reward details
        /// </summary>
        public TaskTrade Trade { get; }
    }
}
