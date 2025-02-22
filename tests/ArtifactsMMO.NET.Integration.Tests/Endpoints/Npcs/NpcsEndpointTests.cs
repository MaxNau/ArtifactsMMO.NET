using ArtifactsMMO.NET.Enums;
using ArtifactsMMO.NET.Integration.Tests.Helpers;
using ArtifactsMMO.NET.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace ArtifactsMMO.NET.Integration.Tests.Endpoints.Npcs
{
    public class NpcsEndpointTests : IClassFixture<TestFixture>
    {
        private readonly IArtifactsMMOClient _client;

        public NpcsEndpointTests(TestFixture fixture)
        {
            _client = fixture.ServiceProvider.GetRequiredService<IArtifactsMMOClient>();
        }

        [Fact]
        public async Task FilterByType_ShouldReturnExpectedData()
        {
            var result = await _client.Npcs.GetAsync(new NpcsQuery(type: NpcType.Merchant));
            Assert.NotNull(result);
            Assert.True(result.Total > 0);
            Assert.NotNull(result.Data);
            Assert.True(result.Data.All(x => x.Type == NpcType.Merchant));
        }

        [Fact]
        public async Task FilterByContentTypeAndCode_ShouldReturnExpectedData()
        {
            var npcCode = "fish_merchant";
            var (result, error) = await _client.Npcs.GetNpcItemsAsync(npcCode);
            Assert.Null(error);
            Assert.NotNull(result);
            Assert.True(result.Total > 0);
            Assert.NotNull(result.Data);
        }

        [Fact]
        public async Task AllData_ShouldReturnExpectedData()
        {
            await PagedDataLoader.GetAllDataAsync(async (page, pageSize) =>
            {
                return await _client.Npcs.GetAsync(new NpcsQuery(page: page, size: pageSize));
            });
        }
    }
}
