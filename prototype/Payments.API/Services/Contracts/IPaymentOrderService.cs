using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Payments.API.Entities;

namespace Payments.API.Services.Contracts
{
    public interface IPaymentOrderService
    {
        Task<PaymentOrder> GetById(int id);

        Task<IEnumerable<PaymentOrder>> GetAll();

        Task<PaymentOrder> Create(PaymentOrder entity);

        Task<PaymentOrder> Modify(PaymentOrder entity);

        Task<bool> DeleteById(int id);
    }
}
