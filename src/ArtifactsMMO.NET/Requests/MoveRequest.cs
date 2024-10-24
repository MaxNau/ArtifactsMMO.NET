namespace ArtifactsMMO.NET.Requests
{
    /// <summary>
    /// Represents a request to move a character to a specified coordinate in the game world.
    /// </summary>
    public class MoveRequest : IRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MoveRequest"/> class with specified coordinates.
        /// </summary>
        /// <param name="x">The X-coordinate to move to.</param>
        /// <param name="y">The Y-coordinate to move to.</param>
        public MoveRequest(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// X-coordinate of the move request.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Y-coordinate of the move request.
        /// </summary>
        public int Y { get; }
    }
}
