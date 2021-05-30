using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orders.API.Entities;

namespace Orders.API.Services.Contracts
{
    public interface IPurchaseOrderService
    {
        Task<PurchaseOrder> GetById(int id);

        Task<IEnumerable<PurchaseOrder>> GetAll();

        Task<PurchaseOrder> Create(PurchaseOrder model);

        Task<bool> DeleteById(int id);
    }
}
