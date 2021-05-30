using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Payments.API.Entities;
using Payments.API.Repositories.Contracts;
using Payments.API.Services.Contracts;

namespace Payments.API.Services.Implementations
{
    public class PaymentOrderService : IPaymentOrderService
    {
        private readonly IPaymentOrderRepository _paymentOrderRepository;

        public PaymentOrderService(IPaymentOrderRepository paymentOrderRepository)
        {
            _paymentOrderRepository = paymentOrderRepository ?? throw new ArgumentNullException(nameof(paymentOrderRepository));
        }

        public async Task<PaymentOrder> Create(PaymentOrder entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            return await _paymentOrderRepository.Create(entity);
        }

        public async Task<bool> DeleteById(int id)
        {
            PaymentOrder entity = await _paymentOrderRepository.GetById(id);
            if(entity != null)
            {
                return await _paymentOrderRepository.DeleteById(id);
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<PaymentOrder>> GetAll()
        {
            return await _paymentOrderRepository.GetAll();
        }

        public async Task<PaymentOrder> GetById(int id)
        {
            return await _paymentOrderRepository.GetById(id);
        }

        public async Task<PaymentOrder> Modify(PaymentOrder entity)
        {
            PaymentOrder oldEntity = await _paymentOrderRepository.GetById(entity.PaymentOrderId);
            if(oldEntity != null)
            {
                entity.CreatedDate = oldEntity.CreatedDate;
                entity.ModifiedDate = DateTime.Now;
                return await _paymentOrderRepository.Modify(entity);
            }
            else
            {
                return null;
            }
        }
    }
}
