using System;
using System.Threading.Tasks;
using Purchase.Aggregator.Models;

namespace Purchase.Aggregator.Services.Contracts
{
    public interface IPaymentService
    {
        Task<PaymentModel> GetPaymentById(int id);
    }
}
