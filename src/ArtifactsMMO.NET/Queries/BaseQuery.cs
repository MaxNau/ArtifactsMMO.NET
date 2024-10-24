namespace ArtifactsMMO.NET.Queries
{
    /// <summary>
    /// Serves as the base class for query objects in the Artifacts MMO API.
    /// </summary>
    /// <remarks>
    /// This class provides common functionality for derived query classes, including 
    /// a property to indicate whether the query has parameters.
    /// </remarks>
    public abstract class BaseQuery
    {
        /// <summary>
        /// Gets or sets a value indicating whether the query has parameters.
        /// </summary>
        /// <remarks>
        /// This property is initialized to <c>true</c> by default. It can be set to <c>false</c> 
        /// to indicate that the query does not have any parameters.
        /// </remarks>
        protected bool HasParameters { get; set; } = true;
    }

}
