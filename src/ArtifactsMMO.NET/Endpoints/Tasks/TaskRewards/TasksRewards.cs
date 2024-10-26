using ArtifactsMMO.NET.Enums.ErrorCodes.Tasks;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Objects.Tasks;
using ArtifactsMMO.NET.Queries;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ArtifactsMMO.NET.Endpoints.Tasks.TaskRewards
{
    internal class TasksRewards : ArtifactsMMOEndpoint, ITasksRewards
    {
        private readonly string _resource = "tasks/rewards";
        public TasksRewards(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
        }

        public async Task<(TaskReward result, GetTaskRewardError? error)> GetAsync(string code, CancellationToken cancellationToken = default)
        {
            return await GetAsync<TaskReward, GetTaskRewardError>($"{_resource}/{code}", cancellationToken).ConfigureAwait(false);
        }

        public async Task<PagedResponse<TaskReward>> GetAsync(TasksRewardsQuery tasksRewardsQuery,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<TaskReward>(_resource, tasksRewardsQuery, cancellationToken).ConfigureAwait(false);
        }
    }
}
