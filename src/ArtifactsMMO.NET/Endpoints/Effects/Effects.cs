using ArtifactsMMO.NET.Enums.ErrorCodes.Effects;
using ArtifactsMMO.NET.Internal;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Objects.Effects;
using ArtifactsMMO.NET.Queries;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ArtifactsMMO.NET.Endpoints.Effects
{
    internal class Effects : ArtifactsMMOEndpoint, IEffects
    {
        private static readonly string _resource = "effects";

        public Effects(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
        }

        internal Effects(HttpClient httpClient, string apiKey,
            IJsonSerializerOptionsFactory jsonSerializerOptionsFactory)
            : base(httpClient, apiKey, jsonSerializerOptionsFactory)
        {
        }

        public async Task<PagedResponse<Effect>> GetAsync(EffectsQuery query, CancellationToken cancellationToken = default)
        {
            return await GetAsync<Effect>(_resource, query, cancellationToken).ConfigureAwait(false);
        }

        public async Task<(Effect result, GetEffectError? error)> GetAsync(string code, CancellationToken cancellationToken = default)
        {
            return await GetAsync<Effect, GetEffectError>($"{_resource}/{code}", cancellationToken).ConfigureAwait(false);
        }
    }
}
