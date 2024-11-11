using ArtifactsMMO.NET.Integration.Tests.Helpers;
using ArtifactsMMO.NET.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArtifactsMMO.NET.Integration.Tests.Endpoints.Achievements
{
    public class AchievementsEndpointTests : IClassFixture<TestFixture>
    {
        private readonly IArtifactsMMOClient _client;
        private readonly IConfiguration _configuration;

        public AchievementsEndpointTests(TestFixture fixture)
        {
            _client = fixture.ServiceProvider.GetRequiredService<IArtifactsMMOClient>();
            _configuration = fixture.Configuration;
        }

        [Fact]
        public async Task AllData_ShouldReturnExpectedData()
        {
            await PagedDataLoader.GetAllDataAsync(async (page, pageSize) =>
            {
                return await _client.Achievements.GetAsync(new AchievementsQuery(page: page, size: pageSize));
            });
        }
    }
}
