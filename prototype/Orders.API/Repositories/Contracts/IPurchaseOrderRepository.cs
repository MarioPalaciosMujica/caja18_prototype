using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orders.API.Entities;

namespace Orders.API.Repositories.Contracts
{
    public interface IPurchaseOrderRepository
    {
        Task<PurchaseOrder> GetById(int id);

        Task<IEnumerable<PurchaseOrder>> GetAll();

        Task<PurchaseOrder> Create(PurchaseOrder entity);

        Task<bool> DeleteById(int id);
    }
}
