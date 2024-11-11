using ArtifactsMMO.NET.Integration.Tests.Helpers;
using ArtifactsMMO.NET.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArtifactsMMO.NET.Integration.Tests.Endpoints.Events
{
    public class EventsEndpointTests : IClassFixture<TestFixture>
    {
        private readonly IArtifactsMMOClient _client;
        private readonly IConfiguration _configuration;

        public EventsEndpointTests(TestFixture fixture)
        {
            _client = fixture.ServiceProvider.GetRequiredService<IArtifactsMMOClient>();
            _configuration = fixture.Configuration;
        }

        [Fact]
        public async Task AllData_ShouldReturnExpectedData()
        {
            await PagedDataLoader.GetAllDataAsync(async (page, pageSize) =>
            {
                return await _client.Events.GetAllAsync(new EventsQuery(page: page, size: pageSize));
            });

            await PagedDataLoader.GetAllDataAsync(async (page, pageSize) =>
            {
                return await _client.Events.GetActiveAsync(new EventsQuery(page: page, size: pageSize));
            });
        }
    }
}
