using ArtifactsMMO.NET.Enums.ErrorCodes.Accounts;
using ArtifactsMMO.NET.Requests;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ArtifactsMMO.NET.Endpoints.Accounts
{
    internal class Accounts : ArtifactsMMOEndpoint, IAccounts
    {
        public Accounts(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
        }

        public async Task<CreateAccountError?> CreateAccountAsync(CreateAccountRequest createAccountRequest, CancellationToken cancellationToken = default)
        {
            var (_, error) = await PostAsync<string, CreateAccountError>("accounts/create", createAccountRequest, cancellationToken).ConfigureAwait(false);
            return error;
        }
    }
}
