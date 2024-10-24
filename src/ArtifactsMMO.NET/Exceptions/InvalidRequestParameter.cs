using System;

namespace ArtifactsMMO.NET.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when a request parameter is invalid.
    /// </summary>
    /// <remarks>
    /// This exception indicates that a request parameter provided in an API request does not meet the expected criteria.
    /// The error message includes the name of the invalid parameter and the expected value.
    /// </remarks>
    public class InvalidRequestParameter : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidQueryParameter"/> class 
        /// with a specified parameter name and expected value.
        /// </summary>
        /// <param name="parameterName">The name of the invalid request parameter.</param>
        /// <param name="expectedValue">The explanation for the expected value for the parameter.</param>
        internal InvalidRequestParameter(string parameterName, string expectedValue)
            : base($"Invalid request parameter {parameterName}. Expected value explanation: {expectedValue}")
        {
            ParameterName = parameterName;
            ExpectedValue = expectedValue;
        }

        /// <summary>
        /// Name of the invalid query parameter.
        /// </summary>
        public string ParameterName { get; }

        /// <summary>
        /// Explanation of the expected value for the query parameter.
        /// </summary>
        public string ExpectedValue { get; }
    }
}
