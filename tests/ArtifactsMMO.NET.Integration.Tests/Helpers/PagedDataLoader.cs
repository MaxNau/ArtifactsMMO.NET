using ArtifactsMMO.NET.Objects;

namespace ArtifactsMMO.NET.Integration.Tests.Helpers
{
    public static class PagedDataLoader
    {
        public static async Task<List<T>> GetAllDataAsync<T>(Func<int, int, Task<PagedResponse<T>>> getPageAsync, int pageSize = 100, CancellationToken cancellationToken = default)
        {
            int page = 1;
            List<T> allData = [];

            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var dataPage = await getPageAsync(page, pageSize);

                if (dataPage.Data == null || dataPage.Data.Count == 0)
                    break;

                allData.AddRange(dataPage.Data);

                if (allData.Count >= dataPage.Total)
                    break;

                page++;
            }

            return allData;
        }
    }
}
