using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Payments.API.Models;

namespace Payments.API.Services.Contracts
{
    public interface IPaymentOrderService
    {
        Task<PaymentOrderModel> GetById(int id);

        Task<IEnumerable<PaymentOrderModel>> GetAll();

        Task<PaymentOrderModel> Create(PaymentOrderModel model);

        Task<PaymentOrderModel> Modify(PaymentOrderModel model);

        Task<bool> DeleteById(int id);
    }
}
