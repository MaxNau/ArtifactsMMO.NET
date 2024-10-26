using ArtifactsMMO.NET.Enums.ErrorCodes.MyAccount;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Objects.Items;
using ArtifactsMMO.NET.Objects.MyAccount;
using ArtifactsMMO.NET.Queries;
using ArtifactsMMO.NET.Requests;
using ArtifactsMMO.NET.Validators;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ArtifactsMMO.NET.Endpoints.MyAccount
{
    internal class MyAccount : ArtifactsMMOEndpoint, IMyAccount
    {
        private static readonly IValidator<string> _validator = new PasswordFormatValidator();

        public MyAccount(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
        }

        public async Task<Bank> GetBankDetailsAsync(CancellationToken cancellationToken = default)
        {
            return await GetAsync<Bank>("my/bank", cancellationToken).ConfigureAwait(false);
        }

        public async Task<PagedResponse<SimpleItem>> GetBankItemsAsync(BankItemsQuery bankItemsQuery, CancellationToken cancellationToken = default)
        {
            return await GetAsync<SimpleItem>("my/bank/items", bankItemsQuery, cancellationToken).ConfigureAwait(false);
        }

        public async Task<ChangePasswordError?> ChangePasswordAsync(string password, CancellationToken cancellationToken = default)
        {
            _validator.Validate(password);

            var (_, error) = await PostAsync<string, ChangePasswordError>("my/change_password", new PasswordResetRequest(password), cancellationToken).ConfigureAwait(false);
            return error;
        }
    }
}
