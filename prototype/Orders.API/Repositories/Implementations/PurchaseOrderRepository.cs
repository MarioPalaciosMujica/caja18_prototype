using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Orders.API.Data;
using Orders.API.Entities;
using Orders.API.Repositories.Contracts;

namespace Orders.API.Repositories.Implementations
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly OrderContext _orderContext;

        public PurchaseOrderRepository(OrderContext orderContext)
        {
            _orderContext = orderContext ?? throw new ArgumentNullException(nameof(orderContext));
        }

        public async Task<PurchaseOrder> Create(PurchaseOrder entity)
        {
            await _orderContext.PurchaseOrders.AddAsync(entity);
            await _orderContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteById(int id)
        {
            PurchaseOrder entity = await _orderContext.PurchaseOrders.FindAsync(id);
            _orderContext.PurchaseOrders.Remove(entity);
            await _orderContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PurchaseOrder>> GetAll()
        {
            return await _orderContext
                .PurchaseOrders
                .ToListAsync();
        }

        public async Task<PurchaseOrder> GetById(int id)
        {
            return await _orderContext
                .PurchaseOrders
                .FindAsync(id);
        }
    }
}
