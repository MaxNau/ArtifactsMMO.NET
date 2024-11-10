using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Objects.Resources;
using ArtifactsMMO.NET.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArtifactsMMO.NET.Integration.Tests.Endpoints.Resources
{
    public class ResourcesEndpointTests : IClassFixture<TestFixture>
    {
        private readonly IArtifactsMMOClient _client;
        private readonly IConfiguration _configuration;

        public ResourcesEndpointTests(TestFixture fixture)
        {
            _client = fixture.ServiceProvider.GetRequiredService<IArtifactsMMOClient>();
            _configuration = fixture.Configuration;
        }


        [Fact]
        public async Task DefaultResourcesQuery_ShouldReturnExpectedData()
        {
            //Act
            PagedResponse<Resource>? result = await _client.Resources.GetAsync(new ResourcesQuery());


            //Assert

            Assert.NotNull(result);
            Assert.True(result.Total > 0);
            Assert.NotNull(result.Data);
            var firstResource = result.Data.FirstOrDefault();
            Assert.NotNull(firstResource);
        }
    }
}
