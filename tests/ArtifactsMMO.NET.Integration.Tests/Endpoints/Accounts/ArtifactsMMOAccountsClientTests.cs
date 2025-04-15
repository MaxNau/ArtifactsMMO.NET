using ArtifactsMMO.NET.Endpoints.Accounts;
using ArtifactsMMO.NET.Integration.Tests.Helpers;
using ArtifactsMMO.NET.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace ArtifactsMMO.NET.Integration.Tests.Endpoints.Accounts;

public class ArtifactsMMOAccountsClientTests : IClassFixture<TestFixture>
{
    private readonly IArtifactsMMOAccountsClient _client;

    public ArtifactsMMOAccountsClientTests(TestFixture fixture)
    {
        _client = fixture.ServiceProvider.GetRequiredService<IArtifactsMMOAccountsClient>();
    }

    [Fact]
    public async Task GetAccountAchievementsAsync_AllData_ShouldReturnExpectedData()
    {
        await PagedDataLoader.GetAllDataAsync(async (page, pageSize) =>
        {
            var result = await _client.GetAccountAchievementsAsync("Rionis",
                new AccountAchievementsQuery(page: page, size: pageSize));

            return result.result;
        });
    }

    [Fact]
    public async Task GetAccount_ShouldReturnExpectedData()
    {
        var account = await _client.GetAccountAsync("Rionis");
    }
}
