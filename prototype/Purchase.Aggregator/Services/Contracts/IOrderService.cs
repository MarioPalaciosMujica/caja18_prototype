using System;
using System.Threading.Tasks;
using Purchase.Aggregator.Models;

namespace Purchase.Aggregator.Services.Contracts
{
    public interface IOrderService
    {
        Task<PurchaseOrderModel> CreatePurchaseOrder(PurchaseOrderModel model, string bearerToken);
    }
}
