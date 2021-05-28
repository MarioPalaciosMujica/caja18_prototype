using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Payments.API.Entities;
using Payments.API.Models;
using Payments.API.Repositories.Contracts;
using Payments.API.Services.Contracts;

namespace Payments.API.Services.Implementations
{
    public class PaymentOrderService : IPaymentOrderService
    {
        private readonly IPaymentOrderRepository _paymentOrderRepository;
        private readonly IMapper _mapper;

        public PaymentOrderService(IPaymentOrderRepository paymentOrderRepository, IMapper mapper)
        {
            _paymentOrderRepository = paymentOrderRepository ?? throw new ArgumentNullException(nameof(paymentOrderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PaymentOrderModel> Create(PaymentOrderModel model)
        {
            PaymentOrder entity = _mapper.Map<PaymentOrder>(model);
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            entity = await _paymentOrderRepository.Create(entity);
            return _mapper.Map<PaymentOrderModel>(entity);
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

        public async Task<IEnumerable<PaymentOrderModel>> GetAll()
        {
            IEnumerable<PaymentOrder> entities = await _paymentOrderRepository.GetAll();
            return _mapper.Map<IEnumerable<PaymentOrderModel>>(entities);
        }

        public async Task<PaymentOrderModel> GetById(int id)
        {
            PaymentOrder entity = await _paymentOrderRepository.GetById(id);
            return _mapper.Map<PaymentOrderModel>(entity);
        }

        public async Task<PaymentOrderModel> Modify(PaymentOrderModel model)
        {
            PaymentOrder oldEntity = await _paymentOrderRepository.GetById(model.PaymentOrderId);
            if(oldEntity != null)
            {
                PaymentOrder newEntity = _mapper.Map<PaymentOrder>(model);
                newEntity.CreatedDate = oldEntity.CreatedDate;
                newEntity.ModifiedDate = DateTime.Now;
                return _mapper.Map<PaymentOrderModel>(await _paymentOrderRepository.Modify(newEntity));
            }
            else
            {
                return null;
            }
        }
    }
}
