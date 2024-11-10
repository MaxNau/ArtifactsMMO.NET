using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArtifactsMMO.NET.Integration.Tests.Endpoints.Items
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
            var result = await _client.Items.GetAsync(new ItemsQuery());
            Assert.NotNull(result);
            Assert.True(result.Total > 0);
            Assert.NotNull(result.Data);
            var firstItem = result.Data.FirstOrDefault();
            Assert.NotNull(firstItem);
        }

        [Fact]
        public async Task ItemsQuery_FilterByItemType_ShouldReturnExpectedData()
        {
            var result = await _client.Items.GetAsync(new ItemsQuery(type: ItemType.Boots));
            Assert.NotNull(result);
            Assert.True(result.Total > 0);
            Assert.NotNull(result.Data);
            Assert.True(result.Data.All(x => x.Type == ItemType.Boots));
        }

        [Fact]
        public async Task ItemsQuery_FilterItemTypeAndMinLevel_ShouldReturnExpectedData()
        {
            var result = await _client.Items.GetAsync(new ItemsQuery(type: ItemType.Boots, minLevel: 20));
            Assert.NotNull(result);
            Assert.True(result.Total > 0);
            Assert.NotNull(result.Data);
            Assert.True(result.Data.All(x => x.Type == ItemType.Boots && x.Level >= 20));
        }

        [Fact]
        public async Task GetMapByCoordinates_ShouldReturnExpectedData()
        {
            var (result, error) = await _client.Maps.GetAsync(0,0);
            Assert.Null(error);
            Assert.NotNull(result);
        }
    }
}
