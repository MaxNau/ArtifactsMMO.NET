using ArtifactsMMO.NET.Integration.Tests.Helpers;
using ArtifactsMMO.NET.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArtifactsMMO.NET.Integration.Tests.Endpoints.Tasks
{
    public class TasksEndpointTests : IClassFixture<TestFixture>
    {
        private readonly IArtifactsMMOClient _client;
        private readonly IConfiguration _configuration;

        public TasksEndpointTests(TestFixture fixture)
        {
            _client = fixture.ServiceProvider.GetRequiredService<IArtifactsMMOClient>();
            _configuration = fixture.Configuration;
        }

        [Fact]
        public async Task AllData_ShouldReturnExpectedData()
        {
            await PagedDataLoader.GetAllDataAsync(async (page, pageSize) =>
            {
                return await _client.Tasks.GetAsync(new TasksQuery(page: page, size: pageSize));
            });

            await PagedDataLoader.GetAllDataAsync(async (page, pageSize) =>
            {
                return await _client.Tasks.TaskRewards.GetAsync(new TasksRewardsQuery(page: page, size: pageSize));
            });
        }
    }
}
