using System;
using System.Net.Http;
using System.Threading.Tasks;
using Purchase.Aggregator.Extensions;
using Purchase.Aggregator.Models;
using Purchase.Aggregator.Services.Contracts;

namespace Purchase.Aggregator.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _client;

        public PaymentService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<PaymentModel> GetPaymentById(int id, string bearerToken)
        {
            _client.DefaultRequestHeaders.Add("Authorization", bearerToken);
            HttpResponseMessage response = await _client.GetAsync($"/api/v1/PaymentOrder/GetPaymentOrderById/{id}");
            return await response.ReadContentAs<PaymentModel>();
        }
    }
}
