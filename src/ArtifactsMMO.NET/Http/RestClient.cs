using ArtifactsMMO.NET.Errors;
using ArtifactsMMO.NET.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ArtifactsMMO.NET.Http
{
    /// <summary>
    /// Represents a REST client for making HTTP requests to an API.
    /// </summary>
    /// <remarks>
    /// The <see cref="RestClient"/> class provides methods to perform GET and POST requests,
    /// along with handling common response patterns such as deserialization and error handling.
    /// </remarks>
    public class RestClient : IRestClient, IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        private bool _disposedValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestClient"/> class with the specified <see cref="HttpClient"/>.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/> to be used for making requests.</param>
        public RestClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _jsonSerializerOptions = new JsonSerializerOptionsFactory().Get(JsonSerializerOptionsMode.Default);
            FixBaseAddress(_httpClient);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RestClient"/> class with the specified <see cref="HttpClient"/>.
        /// </summary>
        /// <remarks>
        /// Used for testing
        /// </remarks>
        /// <param name="httpClient"></param>
        /// <param name="jsonSerializerOptionsFactory"></param>
        /// <exception cref="ArgumentNullException"></exception>
        internal RestClient(HttpClient httpClient, IJsonSerializerOptionsFactory jsonSerializerOptionsFactory)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _jsonSerializerOptions = jsonSerializerOptionsFactory.Get(JsonSerializerOptionsMode.Test);
            FixBaseAddress(_httpClient);
        }

        /// <summary>
        /// BaseAddress
        /// </summary>
        protected Uri BaseAddress
        {
            get { return _httpClient.BaseAddress; }
            set { _httpClient.BaseAddress = value; }
        }

        internal IRestClient Self => this;

        async Task<(T result, ApiError error)> IRestClient.GetAsync<T>(string requestUri, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync(requestUri).ConfigureAwait(false);
            return await GetResponseContentAsync<T>(response).ConfigureAwait(false);
        }

        async Task<Stream> IRestClient.GetAsStreamAsync(string requestUri, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        }

        async Task<(T result, ApiError error)> IRestClient.PostAsync<T>(string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PostAsync(requestUri, content, cancellationToken).ConfigureAwait(false);
            return await GetResponseContentAsync<T>(response).ConfigureAwait(false);
        }

        async Task<(T result, ApiError error)> IRestClient.PostAsync<T>(string requestUri, Dictionary<string, string> headers, CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri);

            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
            return await GetResponseContentAsync<T>(response).ConfigureAwait(false);
        }

        async Task IRestClient.DeleteAsync(string requestUri, CancellationToken cancellationToken)
        {
            var response = await _httpClient.DeleteAsync(requestUri, cancellationToken).ConfigureAwait(false);
            await GetResponseContentAsync<object>(response).ConfigureAwait(false);
        }

        /// <summary>
        /// Adds a default request header to the <see cref="_httpClient"/>.
        /// </summary>
        /// <param name="headerName">The name of the header to add.</param>
        /// <param name="headerValue">The value of the header to add.</param>
        /// <exception cref="ArgumentNullException">Thrown if the header name or value is null or empty.</exception>
        protected void AddDefaultRequestHeader(string headerName, string headerValue)
        {
            if (string.IsNullOrWhiteSpace(headerName))
            {
                throw new ArgumentNullException(nameof(headerName));
            }

            if (string.IsNullOrWhiteSpace(headerValue))
            {
                throw new ArgumentNullException($"{headerName}:{headerValue}");
            }

            bool headerExists = _httpClient.DefaultRequestHeaders.Contains(headerName);

            if (string.IsNullOrEmpty(headerValue))
            {
                if (!headerExists)
                {
                    throw new ArgumentNullException(nameof(headerValue), $"Header {headerName} value is required and was not provided.");
                }
            }
            else if (!headerExists)
            {
                _httpClient.DefaultRequestHeaders.Add(headerName, headerValue);
            }
        }

        private async Task<(T result, ApiError error)> GetResponseContentAsync<T>(HttpResponseMessage httpResponseMessage)
        {
            var contentAsString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                return (default, new ApiError((int)httpResponseMessage.StatusCode,
                    contentAsString, httpResponseMessage.ReasonPhrase));
            }

            if (string.IsNullOrWhiteSpace(contentAsString))
            {
                return default;
            }

            var result = JsonSerializer.Deserialize<T>(contentAsString, _jsonSerializerOptions);
            return (result, default);
        }

        private void FixBaseAddress(HttpClient httpClient)
        {
            if (httpClient.BaseAddress != null && !httpClient.BaseAddress.OriginalString.EndsWith("/"))
            {
                httpClient.BaseAddress = new Uri(httpClient.BaseAddress.OriginalString + "/");
            }
        }

        /// <summary>
        /// Releases HttpClient instance by calling Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _httpClient.Dispose();
                }

                _disposedValue = true;
            }
        }

        /// <summary>
        /// Releases HttpClient instance by calling Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
