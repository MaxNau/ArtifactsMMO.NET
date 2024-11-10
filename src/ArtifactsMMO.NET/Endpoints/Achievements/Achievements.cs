using ArtifactsMMO.NET.Enums.ErrorCodes.Achievments;
using ArtifactsMMO.NET.Internal;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Objects.Achievements;
using ArtifactsMMO.NET.Queries;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ArtifactsMMO.NET.Endpoints.Achievements
{
    internal class Achievements : ArtifactsMMOEndpoint, IAchievements
    {
        private readonly string _resource = "achievements";
        public Achievements(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
        }

        internal Achievements(HttpClient httpClient, string apiKey,
            IJsonSerializerOptionsFactory jsonSerializerOptionsFactory)
            : base(httpClient, apiKey, jsonSerializerOptionsFactory)
        {
        }

        public async Task<(Achievement result, GetAchievementError? error)> GetAsync(string code, CancellationToken cancellationToken = default)
        {
            return await GetAsync<Achievement, GetAchievementError>($"{_resource}/{code}", cancellationToken).ConfigureAwait(false);
        }

        public async Task<PagedResponse<Achievement>> GetAsync(AchievementsQuery achievementsQuery,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<Achievement>(_resource, achievementsQuery, cancellationToken).ConfigureAwait(false);
        }
    }
}
