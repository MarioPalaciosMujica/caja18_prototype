using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orders.API.Models;

namespace Orders.API.Services.Contracts
{
    public interface IPurchaseOrderService
    {
        Task<PurchaseOrderModel> GetById(int id);

        Task<IEnumerable<PurchaseOrderModel>> GetAll();

        Task<PurchaseOrderModel> Create(PurchaseOrderModel model);

        Task<bool> DeleteById(int id);
    }
}
