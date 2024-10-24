using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Internal;
using ArtifactsMMO.NET.Validators;
using System.Text.Json;

namespace ArtifactsMMO.NET.Queries
{
    /// <summary>
    /// Represents a query for retrieving tasks, supporting pagination and filtering by task type and skill.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="PaginationQuery"/> and implements <see cref="IQueryString"/> 
    /// to facilitate the construction of query strings for API requests.
    /// </remarks>
    public class TasksQuery : PaginationQuery, IQueryString
    {
        private readonly static IValidator<TasksQuery> _validator = new TasksQueryValidator();

        /// <summary>
        /// Initializes a new instance of the <see cref="TasksQuery"/> class with no parameters.
        /// </summary>
        public TasksQuery() : base(null, null) { HasParameters = false; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TasksQuery"/> class with specified parameters.
        /// </summary>
        /// <param name="type">The type of task to filter by.</param>
        /// <param name="skill">The skill associated with the task.</param>
        /// <param name="minLevel">The minimum level required for the task.</param>
        /// <param name="maxLevel">The maximum level allowed for the task.</param>
        /// <param name="page">The page number for pagination.</param>
        /// <param name="size">The number of items per page for pagination.</param>
        /// <exception cref="InvalidQueryParameter"></exception>
        public TasksQuery(TaskType? type = null, TaskSkill? skill = null, int? minLevel = null,
            int? maxLevel = null, int? page = null, int? size = null) : base(page, size)
        {
            Type = type;
            Skill = skill;
            MinLevel = minLevel;
            MaxLevel = maxLevel;
            
            _validator.Validate(this);
        }

        /// <summary>
        /// Type of task to filter by.
        /// </summary>
        public TaskType? Type { get; }

        /// <summary>
        /// Skill associated with the task.
        /// </summary>
        public TaskSkill? Skill { get; }

        /// <summary>
        /// Minimum level required for the task.
        /// </summary>
        public int? MinLevel { get; }

        /// <summary>
        /// Maximum level allowed for the task.
        /// </summary>
        public int? MaxLevel { get; }

        string IQueryString.ToQueryString()
        {
            if (!HasParameters)
            {
                return string.Empty;
            }

            var queryStringBuilder = new QueryStringBuilder();
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Type)), Type?.ToString());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Skill)), Skill?.ToString());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(MaxLevel)), MaxLevel?.ToString());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(MinLevel)), MinLevel?.ToString());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Page)), Page?.ToString());
            queryStringBuilder.AddParameter(JsonNamingPolicy.SnakeCaseLower.ConvertName(nameof(Size)), Size?.ToString());

            return queryStringBuilder.ToString();
        }
    }
}
