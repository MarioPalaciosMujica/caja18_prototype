using System;
using System.Net.Http;
using System.Threading.Tasks;
using Purchase.Aggregator.Extensions;
using Purchase.Aggregator.Models;
using Purchase.Aggregator.Services.Contracts;

namespace Purchase.Aggregator.Services.Implementations
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _client;

        public CatalogService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"/api/v1/Product/GetProductById/{id}");
            return await response.ReadContentAs<ProductModel>();
        }
    }
}
