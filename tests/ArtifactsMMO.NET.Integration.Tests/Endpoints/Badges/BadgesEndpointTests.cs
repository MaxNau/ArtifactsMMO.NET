using ArtifactsMMO.NET.Integration.Tests.Helpers;
using ArtifactsMMO.NET.Queries;
using Microsoft.Extensions.DependencyInjection;


namespace ArtifactsMMO.NET.Integration.Tests.Endpoints.Badges
{
    public class BadgesEndpointTests : IClassFixture<TestFixture>
    {
        private readonly IArtifactsMMOClient _client;

        public BadgesEndpointTests(TestFixture fixture)
        {
            _client = fixture.ServiceProvider.GetRequiredService<IArtifactsMMOClient>();
        }

        [Fact]
        public async Task AllData_ShouldReturnExpectedData()
        {
            await PagedDataLoader.GetAllDataAsync(async (page, pageSize) =>
            {
                return await _client.Badges.GetAsync(new BadgesQuery(page: page, size: pageSize));
            });
        }
    }
}
