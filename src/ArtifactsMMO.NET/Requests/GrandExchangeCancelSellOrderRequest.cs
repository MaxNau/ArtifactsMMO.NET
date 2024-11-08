using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Validators;

namespace ArtifactsMMO.NET.Requests
{
    /// <summary>
    /// Request to cancel sell order at the Grand Exchange
    /// </summary>
    public class GrandExchangeCancelSellOrderRequest : IRequest
    {
        private static readonly IValidator<GrandExchangeCancelSellOrderRequest> _validator = new GrandExchangeCancelSellOrderRequestValidator();

        /// <summary>
        /// Initializes a new instance of the <see cref="GrandExchangeCancelSellOrderRequest"/> class.
        /// </summary>
        /// <param name="id">Order id.</param>
        /// <exception cref="InvalidRequestParameter">Thrown when <paramref name="id"/> is null or whitespace.</exception>

        public GrandExchangeCancelSellOrderRequest(string id)
        {
            Id = id;

            _validator.Validate(this);
        }

        /// <summary>
        /// Order Id
        /// </summary>
        public string Id { get; }
    }
}
