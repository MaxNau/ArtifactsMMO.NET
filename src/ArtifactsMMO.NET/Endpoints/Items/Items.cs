﻿using ArtifactsMMO.NET.Enums.ErrorCodes.Items;
using ArtifactsMMO.NET.Objects;
using ArtifactsMMO.NET.Objects.Achievements;
using ArtifactsMMO.NET.Objects.Items;
using ArtifactsMMO.NET.Queries;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ArtifactsMMO.NET.Endpoints.Items
{
    internal class Items : ArtifactsMMOEndpoint, IItems
    {
        private readonly string _resource = "items";
        public Items(HttpClient httpClient, string apiKey) : base(httpClient, apiKey)
        {
        }

        public async Task<(ItemDetail result, GetItemError? error)> GetAsync(string code, CancellationToken cancellationToken = default)
        {
            return await GetAsync<ItemDetail, GetItemError>($"{_resource}/{code}", cancellationToken).ConfigureAwait(false);
        }

        public async Task<PagedResponse<Item>> GetAsync(ItemsQuery itemsQuery,
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<Item>(_resource, itemsQuery, cancellationToken).ConfigureAwait(false);
        }
    }
}
