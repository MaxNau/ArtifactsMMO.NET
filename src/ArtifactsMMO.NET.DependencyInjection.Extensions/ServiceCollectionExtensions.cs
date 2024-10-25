using ArtifactsMMO.NET.Endpoints.Accounts;
using ArtifactsMMO.NET.Endpoints.Token;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Net.Http;

namespace ArtifactsMMO.NET.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddArtifactsMMOClient(this IServiceCollection services, string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentNullException(nameof(apiKey));
            }

            var client = CreateAndConfigureHttpClient();
            services.AddSingleton<IArtifactsMMOClient>(new ArtifactsMMOClient(client, apiKey));

            return services;
        }

        public static IServiceCollection AddArtifactsMMOAccountsClient(this IServiceCollection services)
        {
            var client = CreateAndConfigureHttpClient();
            services.AddSingleton<IArtifactsMMOTokenClient>(new ArtifactsMMOTokenClient(client));

            return services;
        }

        public static IServiceCollection AddArtifactsMMOTokenClient(this IServiceCollection services)
        {
            var client = CreateAndConfigureHttpClient();
            services.AddSingleton<IArtifactsMMOTokenClient>(new ArtifactsMMOTokenClient(client));

            return services;
        }

        private static HttpClient CreateAndConfigureHttpClient()
        {
            var client = new HttpClient(
#if NET5_0_OR_GREATER || NETCOREAPP2_1_OR_GREATER
                new SocketsHttpHandler
                    {
                        PooledConnectionLifetime = TimeSpan.FromMinutes(2)
                    }, false
#endif
        );
#if NET462_OR_GREATER
            ServicePointManager.FindServicePoint(new Uri("https://api.artifactsmmo.com/")).ConnectionLeaseTimeout = 120000;
#endif
            return client;
        }
    }
}
