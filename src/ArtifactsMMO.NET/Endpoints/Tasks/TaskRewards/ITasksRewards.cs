using ArtifactsMMO.NET.Objects.Tasks;
using System.Threading.Tasks;
using System.Threading;
using ArtifactsMMO.NET.Queries;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Enums.ErrorCodes.Tasks;
using ArtifactsMMO.NET.Exceptions;

namespace ArtifactsMMO.NET.Endpoints.Tasks.TaskRewards
{
    /// <summary>
    /// Provides methods for retrieving task reward-related information.
    /// </summary>
    public interface ITasksRewards
    {
        /// <summary>
        /// Retrieve the details of a tasks reward.
        /// </summary>
        /// <param name="code">The unique code of the task reward to retrieve.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a tuple with the <see cref="TaskReward"/> retrieved and an optional <see cref="GetTaskRewardError"/>.</returns>
        /// <exception cref="ApiException"></exception>
        Task<(TaskReward result, GetTaskRewardError? error)> GetAsync(string code, CancellationToken cancellationToken = default);

        /// <summary>
        /// Fetch the list of all tasks rewards.
        /// </summary>
        /// <remarks>
        /// To obtain these rewards, you must exchange 6 task coins with a tasks master.
        /// </remarks>
        /// <param name="tasksRewardsQuery">The query <see cref="TasksRewardsQuery"/> to filter task rewards.</param>
        /// <param name="cancellationToken">A token for canceling the asynchronous operation.</param>
        /// <returns>A task representing the asynchronous operation.
        /// The task result contains a <see cref="PagedResponse{TaskReward}"/> with the filtered task rewards.</returns>
        /// <exception cref="ApiException"></exception>
        Task<PagedResponse<TaskReward>> GetAsync(TasksRewardsQuery tasksRewardsQuery, CancellationToken cancellationToken = default);
    }

}
