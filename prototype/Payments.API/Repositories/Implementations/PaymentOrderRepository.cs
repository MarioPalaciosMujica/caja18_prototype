using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Payments.API.Data;
using Payments.API.Entities;
using Payments.API.Repositories.Contracts;

namespace Payments.API.Repositories.Implementations
{
    public class PaymentOrderRepository : IPaymentOrderRepository
    {
        private readonly PaymentContext _paymentContext;

        public PaymentOrderRepository(PaymentContext paymentContext)
        {
            _paymentContext = paymentContext ?? throw new ArgumentNullException(nameof(paymentContext));
        }

        public async Task<PaymentOrder> Create(PaymentOrder entity)
        {
            await _paymentContext.PaymentOrders.AddAsync(entity);
            await _paymentContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteById(int id)
        {
            PaymentOrder entity = await _paymentContext.PaymentOrders.FindAsync(id);
            _paymentContext.PaymentOrders.Remove(entity);
            return true;
        }

        public async Task<IEnumerable<PaymentOrder>> GetAll()
        {
            return await _paymentContext
                .PaymentOrders
                .ToListAsync();
        }

        public async Task<IEnumerable<PaymentOrder>> GetAllByUserName(string userName)
        {
            return await _paymentContext
                .PaymentOrders
                .ToListAsync();
        }

        public async Task<PaymentOrder> GetById(int id)
        {
            return await _paymentContext
                .PaymentOrders
                .FindAsync(id);
        }

        public async Task<PaymentOrder> Modify(PaymentOrder entity)
        {
            _paymentContext.PaymentOrders.Update(entity);
            await _paymentContext.SaveChangesAsync();
            return entity;
        }
    }
}
