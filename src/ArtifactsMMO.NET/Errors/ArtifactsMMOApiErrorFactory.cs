using ArtifactsMMO.NET.Exceptions;
using System;

namespace ArtifactsMMO.NET.Errors
{
    internal class ArtifactsMMOApiErrorFactory
    {
        public T? Get<T>(ApiError error) where T : struct, Enum
        {
            if (error == null)
            {
                return default;
            }

            if (Enum.IsDefined(typeof(T), error.StatusCode))
            {
                return (T)(object)error.StatusCode;
            }

            throw new ApiException(error.StatusCode, error.ReasonPhrase, error.ContentAsString);
        }
    }
}
