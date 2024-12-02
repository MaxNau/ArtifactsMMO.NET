using ArtifactsMMO.NET.Enums.ErrorCodes.Character;
using ArtifactsMMO.NET.Internal;
using ArtifactsMMO.NET.Objects.Characters;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using ArtifactsMMO.NET.Objects.Badges;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Queries;

namespace ArtifactsMMO.NET.Endpoints.Badges
{
    internal class Badges : ArtifactsMMOEndpoint, IBadges
    {
        public Badges(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
        }

        internal Badges(HttpClient httpClient, string apiKey,
            IJsonSerializerOptionsFactory jsonSerializerOptionsFactory)
            : base(httpClient, apiKey, jsonSerializerOptionsFactory)
        {
        }

        public async Task<PagedResponse<Badge>> GetAsync(BadgesQuery query, CancellationToken cancellationToken = default)
        {
            return await GetAsync<Badge>("badges", query, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(Badge result, GetBadgeError? error)> GetAsync(string code, CancellationToken cancellationToken = default)
        {
            return await GetAsync<Badge, GetBadgeError>($"badges/{code}", cancellationToken).ConfigureAwait(false);
        }
    }
}
