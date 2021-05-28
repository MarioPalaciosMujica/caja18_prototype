using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Purchase.Aggregator.Extensions;
using Purchase.Aggregator.Models;
using Purchase.Aggregator.Services.Contracts;

namespace Purchase.Aggregator.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;

        public OrderService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<PurchaseOrderModel> CreatePurchaseOrder(PurchaseOrderModel model)
        {
            string data = JsonSerializer.Serialize<PurchaseOrderModel>(model);
            HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync("/api/v1/PurchaseOrder/CreatePurchaseOrder", content);
            return await response.ReadContentAs<PurchaseOrderModel>();
        }
    }
}
