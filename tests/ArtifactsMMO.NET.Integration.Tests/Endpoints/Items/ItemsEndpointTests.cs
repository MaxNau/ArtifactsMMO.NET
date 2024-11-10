using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArtifactsMMO.NET.Integration.Tests.Endpoints.Maps
{
    public class ItemsEndpointTests : IClassFixture<TestFixture>
    {
        private readonly IArtifactsMMOClient _client;
        private readonly IConfiguration _configuration;

        public ItemsEndpointTests(TestFixture fixture)
        {
            _client = fixture.ServiceProvider.GetRequiredService<IArtifactsMMOClient>();
            _configuration = fixture.Configuration;
        }

        [Fact]
        public async Task DefaultItemsQuery_ShouldReturnExpectedData()
        {
            //Act
            var result = await _client.Items.GetAsync(new ItemsQuery());

            //Assert
            Assert.NotNull(result);
            Assert.True(result.Total > 0);
            Assert.NotNull(result.Data);
            var firstMap = result.Data.FirstOrDefault();
            Assert.NotNull(firstMap);
        }

    }
}
