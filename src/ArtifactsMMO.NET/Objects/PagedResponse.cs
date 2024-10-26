using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ArtifactsMMO.NET.Objects
{
    /// <summary>
    /// Represents a paginated response from an API, containing a collection of data and metadata about the pagination.
    /// </summary>
    /// <typeparam name="T">The type of items in the paginated response.</typeparam>
    public class PagedResponse<T>
    {
        internal PagedResponse() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedResponse{T}"/> class with specified data and pagination details.
        /// </summary>
        /// <param name="data">The collection of items returned in the current page.</param>
        /// <param name="total">The total number of items available across all pages.</param>
        /// <param name="page">The current page number.</param>
        /// <param name="size">The number of items per page.</param>
        /// <param name="pages">The total number of pages available.</param>
        [JsonConstructor]
        internal PagedResponse(IReadOnlyCollection<T> data, int total, int page, int size, int pages)
        {
            Data = data;
            Total = total;
            Page = page;
            Size = size;
            Pages = pages;
        }

        /// <summary>
        /// Collection of items returned in the current page.
        /// </summary>
        public IReadOnlyCollection<T> Data { get; }

        /// <summary>
        /// Total number of items available across all pages.
        /// </summary>
        public int Total { get; }

        /// <summary>
        /// Current page number.
        /// </summary>
        public int Page { get; }

        /// <summary>
        /// Number of items per page.
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// Total number of pages available.
        /// </summary>
        public int Pages { get; }
    }
}
