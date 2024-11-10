using System;

namespace ArtifactsMMO.NET.Exceptions
{
    /// <summary>
    /// Represents an error that occurs during API requests and is not handled in the code.
    /// </summary>
    public class ApiException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class with specified details.
        /// </summary>
        /// <param name="statusCode">The HTTP status code associated with the error.</param>
        /// <param name="message">A message describing the error.</param>
        /// <param name="contentAsString">The content returned from the API as a string.</param>
        internal ApiException(int statusCode, string message, string contentAsString)
            : base($"{statusCode} {message} {contentAsString}")
        {
            StatusCode = statusCode;
            ContentAsString = contentAsString;
        }

        /// <summary>
        /// Status code associated with the error.
        /// </summary>
        public int StatusCode { get; }

        /// <summary>
        /// Content returned from the API as a string describing error details.
        /// </summary>
        public string ContentAsString { get; }
    }
}