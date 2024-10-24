using System.Threading.Tasks;
using System.Threading;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Queries;
using ArtifactsMMO.NET.Endpoints.Tasks.TaskRewards;
using ArtifactsMMO.NET.Enums.ErrorCodes.Tasks;
using ArtifactsMMO.NET.Exceptions;

namespace ArtifactsMMO.NET.Endpoints.Tasks
{
    /// <summary>
    /// Provides methods for managing tasks and retrieving task-related information.
    /// </summary>
    public interface ITasks
    {
        /// <summary>
        /// Task rewards client
        /// </summary>
        /// <value>An instance of <see cref="ITasksRewards"/> that provides access to task rewards endpoints.</value>
        ITasksRewards TaskRewards { get; }

        /// <summary>
        /// Retrieve the details of a task.
        /// </summary>
        /// <param name="code">The unique code of the task to retrieve.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="Objects.Tasks.Task"/> retrieved and an optional <see cref="GetTaskError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(Objects.Tasks.Task result, GetTaskError? error)> GetAsync(string code, CancellationToken cancellationToken = default);

        /// <summary>
        /// Fetch the list of all tasks.
        /// </summary>
        /// <param name="tasksQuery">The query <see cref="TasksQuery"/> to filter tasks.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a <see cref="PagedResponse{T}"/> (where T is <see cref="Objects.Tasks.Task"/>) with the filtered tasks.</returns>
        /// <exception cref="ApiException"></exception>
        Task<PagedResponse<Objects.Tasks.Task>> GetAsync(TasksQuery tasksQuery, CancellationToken cancellationToken = default);
    }

}
