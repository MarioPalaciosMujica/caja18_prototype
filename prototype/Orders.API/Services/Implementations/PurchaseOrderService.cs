using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orders.API.Entities;
using Orders.API.Repositories.Contracts;
using Orders.API.Services.Contracts;

namespace Orders.API.Services.Implementations
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public PurchaseOrderService(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository ?? throw new ArgumentNullException(nameof(purchaseOrderRepository));
        }

        public async Task<PurchaseOrder> Create(PurchaseOrder entity)
        {
            entity.TaxesAmount = calculateTaxes(entity.PriceAmount);
            entity.TotalAmount = entity.PriceAmount + entity.TaxesAmount;
            entity.CreatedDate = DateTime.Now;
            entity.ModifyDate = DateTime.Now;
            return await _purchaseOrderRepository.Create(entity);
        }

        public async Task<bool> DeleteById(int id)
        {
            PurchaseOrder entity = await _purchaseOrderRepository.GetById(id);
            if(entity != null)
            {
                return await _purchaseOrderRepository.DeleteById(id);
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<PurchaseOrder>> GetAll()
        {
            return await _purchaseOrderRepository.GetAll();
        }

        public async Task<PurchaseOrder> GetById(int id)
        {
            return await _purchaseOrderRepository.GetById(id);
        }

        private decimal calculateTaxes(decimal priceAmount, double percentage = 0.19)
        {
            decimal tax = (decimal)((double)priceAmount * percentage);
            return Math.Round(tax, MidpointRounding.AwayFromZero);
        }
    }
}
