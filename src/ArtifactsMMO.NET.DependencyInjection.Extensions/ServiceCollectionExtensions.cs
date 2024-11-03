using ArtifactsMMO.NET.Endpoints.Accounts;
using ArtifactsMMO.NET.Endpoints.Assets;
using ArtifactsMMO.NET.Endpoints.Token;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Net.Http;

namespace ArtifactsMMO.NET.DependencyInjection.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="IServiceCollection"/> to register
    /// clients for interacting with the Artifacts MMO services.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ArtifactsMMOClient"/> to the service collection.
        /// </summary>
        /// <param name="services">The service collection to which the client will be added.</param>
        /// <param name="apiKey">The API key required for authenticating requests.</param>
        /// <returns>The updated <see cref="IServiceCollection"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="apiKey"/> is null or whitespace.</exception>
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

        /// <summary>
        /// Adds the <see cref="ArtifactsMMOTokenClient"/> to the service collection.
        /// </summary>
        /// <param name="services">The service collection to which the client will be added.</param>
        /// <returns>The updated <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddArtifactsMMOAccountsClient(this IServiceCollection services)
        {
            var client = CreateAndConfigureHttpClient();
            services.AddSingleton<IArtifactsMMOAccountsClient>(new ArtifactsMMOAccountsClient(client));

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ArtifactsMMOTokenClient"/> to the service collection.
        /// </summary>
        /// <param name="services">The service collection to which the client will be added.</param>
        /// <returns>The updated <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddArtifactsMMOTokenClient(this IServiceCollection services)
        {
            var client = CreateAndConfigureHttpClient();
            services.AddSingleton<IArtifactsMMOTokenClient>(new ArtifactsMMOTokenClient(client));

            return services;
        }

        /// <summary>
        /// Adds the <see cref="ArtifactsMMOAssetsClient"/> to the service collection.
        /// </summary>
        /// <param name="services">The service collection to which the client will be added.</param>
        /// <returns>The updated <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddArtifactsMMOAssetsClient(this IServiceCollection services)
        {
            var client = CreateAndConfigureHttpClient();
            services.AddSingleton<IArtifactsMMOAssetsClient>(new ArtifactsMMOAssetsClient(client));

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
