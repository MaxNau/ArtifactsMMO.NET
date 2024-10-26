using ArtifactsMMO.NET.Errors;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ArtifactsMMO.NET.Http
{
    internal interface IRestClient
    {
        Task<(T result, ApiError error)> GetAsync<T>(string requestUri, CancellationToken cancellationToken);
        Task<Stream> GetAsStreamAsync(string requestUri, CancellationToken cancellationToken);
        Task<(T result, ApiError error)> PostAsync<T>(string requestUri, HttpContent content, CancellationToken cancellationToken);
        Task<(T result, ApiError error)> PostAsync<T>(string requestUri, Dictionary<string, string> headers, CancellationToken cancellationToken);
        Task DeleteAsync(string requestUri, CancellationToken cancellationToken);
    }
}
