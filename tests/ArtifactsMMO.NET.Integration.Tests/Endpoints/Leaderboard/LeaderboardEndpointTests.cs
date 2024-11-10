using ArtifactsMMO.NET.Integration.Tests.Helpers;
using ArtifactsMMO.NET.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArtifactsMMO.NET.Integration.Tests.Endpoints.Leaderboard
{
    public class LeaderboardEndpointTests : IClassFixture<TestFixture>
    {
        private readonly IArtifactsMMOClient _client;
        private readonly IConfiguration _configuration;

        public LeaderboardEndpointTests(TestFixture fixture)
        {
            _client = fixture.ServiceProvider.GetRequiredService<IArtifactsMMOClient>();
            _configuration = fixture.Configuration;
        }

        [Fact]
        public async Task AllData_ShouldReturnExpectedData()
        {
            await PagedDataLoader.GetAllDataAsync(async (page, pageSize) =>
            {
                return await _client.Leaderboard.GetAsync(new CharactersLeaderboardQuery(page: page, size: pageSize));
            });

            await PagedDataLoader.GetAllDataAsync(async (page, pageSize) =>
            {
                return await _client.Leaderboard.GetAsync(new AccountsLeaderboardQuery(page: page, size: pageSize));
            });
        }
    }
}