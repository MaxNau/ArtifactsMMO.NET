using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Queries;

namespace ArtifactsMMO.NET.Validators
{
    internal class TasksQueryValidator : IValidator<TasksQuery>
    {
        public void Validate(TasksQuery tasksQuery)
        {
            if (tasksQuery.MaxLevel.HasValue && tasksQuery.MaxLevel.Value < 0)
            {
                throw new InvalidQueryParameter(nameof(tasksQuery.MaxLevel), ">=0");
            }

            if (tasksQuery.MinLevel.HasValue && tasksQuery.MinLevel.Value < 0)
            {
                throw new InvalidQueryParameter(nameof(tasksQuery.MinLevel), ">=0");
            }
        }
    }
}
