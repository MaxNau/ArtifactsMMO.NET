﻿using ArtifactsMMO.NET.Exceptions;
using ArtifactsMMO.NET.Validators;

namespace ArtifactsMMO.NET.Requests
{
    /// <summary>
    /// Request to sell an item to the NPC.
    /// </summary>
    public class NpcSellItemRequest : IRequest
    {
        private static readonly IValidator<NpcSellItemRequest> _validator = new NpcSellItemRequestValidator();

        /// <summary>
        /// Initializes a new instance of the <see cref="NpcSellItemRequest"/> class.
        /// </summary>
        /// <param name="code">The code representing the item to buy or sell to the NPC.</param>
        /// <param name="quantity">The number of items to buy/sell.</param>
        /// <exception cref="ItemCodeHasDisallowedCharacters">Thrown when <paramref name="code"/> contains not allowed characters. Should match pattern ^[a-zA-Z0-9_-]+$</exception>
        /// <exception cref="DisallowedNpcQuantity">Thrown when <paramref name="quantity"/> is not from 1 to 100 inclusive.</exception>
        public NpcSellItemRequest(string code, int quantity)
        {
            Code = code;
            Quantity = quantity;
            _validator.Validate(this);
        }
        /// <summary>
        /// Item code.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Item quantity.
        /// </summary>
        public int Quantity { get; }
    }
}
