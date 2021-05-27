using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Orders.API.Entities;
using Orders.API.Models;
using Orders.API.Repositories.Contracts;
using Orders.API.Services.Contracts;

namespace Orders.API.Services.Implementations
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;
        private readonly IMapper _mapper;

        public PurchaseOrderService(IPurchaseOrderRepository purchaseOrderRepository, IMapper mapper)
        {
            _purchaseOrderRepository = purchaseOrderRepository ?? throw new ArgumentNullException(nameof(purchaseOrderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PurchaseOrderModel> Create(PurchaseOrderModel model)
        {
            PurchaseOrder entity = await _purchaseOrderRepository.Create(_mapper.Map<PurchaseOrder>(model));
            entity.TaxesAmount = calculateTaxes(entity.PriceAmount);
            entity.TotalAmount = entity.PriceAmount + entity.TaxesAmount;
            return _mapper.Map<PurchaseOrderModel>(entity);
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

        public async Task<IEnumerable<PurchaseOrderModel>> GetAll()
        {
            IEnumerable<PurchaseOrder> entities = await _purchaseOrderRepository.GetAll();
            return _mapper.Map<IEnumerable<PurchaseOrderModel>>(entities);
        }

        public async Task<PurchaseOrderModel> GetById(int id)
        {
            PurchaseOrder entity = await _purchaseOrderRepository.GetById(id);
            return _mapper.Map<PurchaseOrderModel>(entity);
        }

        private decimal calculateTaxes(decimal priceAmount, decimal percentage = 19)
        {
            decimal tax = (decimal)((double)priceAmount * 0.19);
            return Math.Round(tax, MidpointRounding.AwayFromZero);
        }
    }
}
