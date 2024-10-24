using ArtifactsMMO.NET.Endpoints.Tasks.TaskRewards;
using ArtifactsMMO.NET.Enums.ErrorCodes.Tasks;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Queries;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ArtifactsMMO.NET.Endpoints.Tasks
{
    internal class Tasks : ArtifactsMMOEndpoint, ITasks
    {
        private readonly string _resource = "tasks/list";

        public Tasks(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
            TaskRewards = new TasksRewards(httpClient, apiKey);
        }

        public ITasksRewards TaskRewards { get; }

        public async Task<(Objects.Tasks.Task result, GetTaskError? error)> GetAsync(string code, CancellationToken cancellationToken = default)
        {
            return await GetAsync<Objects.Tasks.Task, GetTaskError>($"{_resource}/{code}", cancellationToken).ConfigureAwait(false);
        }

        public async Task<PagedResponse<Objects.Tasks.Task>> GetAsync(TasksQuery tasksQuery,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<Objects.Tasks.Task>(_resource, tasksQuery, cancellationToken).ConfigureAwait(false);
        }
    }
}
