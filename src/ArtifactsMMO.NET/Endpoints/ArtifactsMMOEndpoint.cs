using ArtifactsMMO.NET.Http;
using ArtifactsMMO.NET.Internal;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Queries;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using ArtifactsMMO.NET.Requests;
using System.Text.Json;
using ArtifactsMMO.NET.Errors;
using ArtifactsMMO.NET.Exceptions;
using System.Text;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Endpoints
{
    /// <summary>
    /// Represents an abstract base class for endpoints in the Artifacts MMO API.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="RestClient"/> and serves as a foundation
    /// for specific API endpoint implementations related to the Artifacts MMO game.
    /// It provides common functionality for making HTTP requests to the API.
    /// </remarks>
    public abstract class ArtifactsMMOEndpoint : RestClient
    {
        private readonly Uri _baseUri = new Uri("https://api.artifactsmmo.com/");
        private readonly ArtifactsMMOApiErrorFactory _errorFactory;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArtifactsMMOEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/> used for making HTTP requests to the API.</param>
        private protected ArtifactsMMOEndpoint(HttpClient httpClient) : base(httpClient)
        {
            _jsonSerializerOptions = new JsonSerializerOptionsFactory().Get(JsonSerializerOptionsMode.Default);
            _errorFactory = new ArtifactsMMOApiErrorFactory();
            SetBaseAddress();
            SetUserAgent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArtifactsMMOEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/> used for making HTTP requests to the API.</param>
        /// <param name="apiKey">The API key for authenticating requests to the API.</param>
        /// <remarks>
        /// This constructor sets the base address for the API, initializes the query string builder,
        /// and adds the default request header for authorization using the provided API key.
        /// </remarks>
        protected ArtifactsMMOEndpoint(HttpClient httpClient, string apiKey) : base(httpClient)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentNullException(nameof(apiKey));
            }

            _jsonSerializerOptions = new JsonSerializerOptionsFactory().Get(JsonSerializerOptionsMode.Default);
            _errorFactory = new ArtifactsMMOApiErrorFactory();
            SetBaseAddress();
            AddDefaultRequestHeader("Authorization", $"Bearer {apiKey}");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArtifactsMMOEndpoint"/> class.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/> used for making HTTP requests to the API.</param>
        /// <param name="apiKey">The API key for authenticating requests to the API.</param>
        /// <param name="jsonSerializerOptionsFactory"></param>
        /// <remarks>
        /// Used for testing
        /// </remarks>
        internal ArtifactsMMOEndpoint(HttpClient httpClient, string apiKey,
            IJsonSerializerOptionsFactory jsonSerializerOptionsFactory)
            : base(httpClient, jsonSerializerOptionsFactory)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentNullException(nameof(apiKey));
            }
            
            _jsonSerializerOptions = new JsonSerializerOptionsFactory().Get(JsonSerializerOptionsMode.Test);
            _errorFactory = new ArtifactsMMOApiErrorFactory();
            SetBaseAddress();
            AddDefaultRequestHeader("Authorization", $"Bearer {apiKey}");
        }

        internal async Task<T> GetAsync<T>(string resource,
            CancellationToken cancellationToken = default)
        {
            var (result, error) = await Self.GetAsync<Response<T>>(resource, cancellationToken).ConfigureAwait(false);
            
            if (error != null)
            {
                throw new ApiException(error.StatusCode, error.ReasonPhrase, error.ContentAsString);
            }

            return result != null ? result.Data : default;
        }

        internal async Task<(T result, E? error)> GetAsync<T, E>(string resource,
            CancellationToken cancellationToken = default) where E : struct, Enum
        {
            var (result, error) = await Self.GetAsync<Response<T>>(resource, cancellationToken).ConfigureAwait(false);

            var errorCode = _errorFactory.Get<E>(error);
            return (result != null ? result.Data : default, errorCode);
        }

        internal async Task<PagedResponse<T>> GetAsync<T>(string resource, IQueryString query,
            CancellationToken cancellationToken = default)
        {
            var (result, error) = await Self.GetAsync<PagedResponse<T>>($"{resource}{query?.ToQueryString()}", cancellationToken).ConfigureAwait(false);

            if (error != null)
            {
                throw new ApiException(error.StatusCode, error.ReasonPhrase, error.ContentAsString);
            }

            return result;
        }

        internal async Task<(PagedResponse<T> result, E? error)> GetAsync<T, E>(string resource, IQueryString query,
            CancellationToken cancellationToken = default) where E : struct, Enum
        {
            var(result, error) = await Self.GetAsync<PagedResponse<T>>($"{resource}{query?.ToQueryString()}", cancellationToken).ConfigureAwait(false);

            var errorCode = _errorFactory.Get<E>(error);
            return (result, errorCode);
        }

        internal async Task<(T result, E? error)> PostAsync<T, E>(string resource, IRequest request, CancellationToken cancellationToken = default) where E : struct, Enum
        {
            var body = JsonSerializer.Serialize(request, _jsonSerializerOptions);
            using (var httpContent = new StringContent(body, Encoding.UTF8, "application/json"))
            {
                var (result, error) = await Self.PostAsync<Response<T>>(resource, httpContent, cancellationToken).ConfigureAwait(false);

                var errorCode = _errorFactory.Get<E>(error);
                return (result != null ? result.Data : default, errorCode);
            }
        }

        private void SetBaseAddress()
        {
            if (BaseAddress == null || BaseAddress.OriginalString != _baseUri.OriginalString)
            {
                BaseAddress = _baseUri;
            }
        }

        private void SetUserAgent()
        {
            AddDefaultRequestHeader("User-Agent", $"ArtifactsMMO.NET/{VersionHelper.Version}");
        }
    }
}
