using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Requests;

namespace ArtifactsMMO.NET.Validators
{
    internal class GrandExchangeCancelSellOrderRequestValidator : IValidator<GrandExchangeCancelSellOrderRequest>
    {
        public void Validate(GrandExchangeCancelSellOrderRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Id))
            {
                throw new InvalidRequestParameter(nameof(request.Id), "Must not be empty");
            }
        }
    }
}
