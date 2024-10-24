namespace ArtifactsMMO.NET.Errors
{
    /// <summary>
    /// Represents an error response from the API.
    /// </summary>
    public class ApiError
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiError"/> class with the specified status code, content, and reason phrase.
        /// </summary>
        /// <param name="statusCode">The HTTP status code associated with the error.</param>
        /// <param name="contentAsString">The content of the error response as a string.</param>
        /// <param name="reasonPhrase">The reason phrase associated with the status code.</param>
        public ApiError(int statusCode, string contentAsString, string reasonPhrase)
        {
            StatusCode = statusCode;
            ContentAsString = contentAsString;
            ReasonPhrase = reasonPhrase;
        }

        /// <summary>
        /// HTTP status code associated with the error.
        /// </summary>
        public int StatusCode { get; }

        /// <summary>
        /// Content of the error response as a string.
        /// </summary>
        public string ContentAsString { get; }

        /// <summary>
        /// Reason phrase associated with the status code.
        /// </summary>
        public string ReasonPhrase { get; }
    }
}
