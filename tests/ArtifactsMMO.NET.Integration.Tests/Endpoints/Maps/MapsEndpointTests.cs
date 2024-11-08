using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArtifactsMMO.NET.Integration.Tests.Endpoints.Maps
{
    public class MapsEndpointTests : IClassFixture<TestFixture>
    {
        private readonly IArtifactsMMOClient _client;
        private readonly IConfiguration _configuration;

        public MapsEndpointTests(TestFixture fixture)
        {
            _client = fixture.ServiceProvider.GetRequiredService<IArtifactsMMOClient>();
            _configuration = fixture.Configuration;
        }

        [Fact]
        public async Task DefaultMapsQuery_ShouldReturnExpectedData()
        {
            var result = await _client.Maps.GetAsync(new MapsQuery());
            Assert.NotNull(result);
            Assert.True(result.Total > 0);
            Assert.NotNull(result.Data);
            var firstMap = result.Data.FirstOrDefault();
            Assert.NotNull(firstMap);
        }

        [Fact]
        public async Task MapsQuery_FilterByContentType_ShouldReturnExpectedData()
        {
            var result = await _client.Maps.GetAsync(new MapsQuery(contentType: MapContentType.Monster));
            Assert.NotNull(result);
            Assert.True(result.Total > 0);
            Assert.NotNull(result.Data);
            Assert.True(result.Data.All(x => x.Content.Type == MapContentType.Monster));
        }

        [Fact]
        public async Task MapsQuery_FilterByContentTypeAndCode_ShouldReturnExpectedData()
        {
            var contentCode = "green_slime";
            var result = await _client.Maps.GetAsync(new MapsQuery(contentCode, contentType: MapContentType.Monster));
            Assert.NotNull(result);
            Assert.True(result.Total > 0);
            Assert.NotNull(result.Data);
            Assert.True(result.Data.All(x => x.Content.Type == MapContentType.Monster && x.Content.Code == contentCode));
        }

        [Fact]
        public async Task GetMapByCoordinates_ShouldReturnExpectedData()
        {
            var (result, error) = await _client.Maps.GetAsync(0,0);
            Assert.NotNull(result);
        }
    }
}
