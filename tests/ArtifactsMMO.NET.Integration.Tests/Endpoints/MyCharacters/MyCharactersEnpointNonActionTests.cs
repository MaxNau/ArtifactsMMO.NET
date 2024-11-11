using ArtifactsMMO.NET.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArtifactsMMO.NET.Integration.Tests.Endpoints.MyCharacters
{
    public class MyCharactersEnpointNonActionTests : IClassFixture<TestFixture>
    {
        private readonly IArtifactsMMOClient _client;
        private readonly IConfiguration _configuration;

        public MyCharactersEnpointNonActionTests(TestFixture fixture)
        {
            _client = fixture.ServiceProvider.GetRequiredService<IArtifactsMMOClient>();
            _configuration = fixture.Configuration;
        }

        [Fact]
        public async Task GetCharactersLogs_ShouldReturnExpectedData()
        {
            var (result, error) = await _client.MyCharacters.GetAllCharactersLogsAsync(new AllCharactersLogsQuery());

            Assert.NotNull(result);
            Assert.NotNull(result.Data);
            Assert.Null(error);
        }

        [Fact]
        public async Task GetCharacters_ShouldReturnExpectedData()
        {
            var characters = await _client.MyCharacters.GetMyCharactersAsync();
            Assert.NotNull(characters);
        }
    }
}
