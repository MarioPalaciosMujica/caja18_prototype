using System;
using Payments.API.Entities;

namespace Payments.API.Data
{
    public class PaymentSeed
    {
        public static void PopulateDatabase(PaymentContext paymentContext)
        {
            PaymentOrder pay1 = new PaymentOrder
            {
                PaymentOrderId = 1,
                BankName = "Santander",
                PaymentMethod = "WebPay Plus",
                Amount = 50000,
                IsValid = true,
                CreatedDate = new DateTime(),
                ModifiedDate = new DateTime()
            };
            paymentContext.Add(pay1);

            PaymentOrder pay2 = new PaymentOrder
            {
                PaymentOrderId = 2,
                BankName = "Banco Estado",
                PaymentMethod = "PayPal",
                Amount = 100000,
                IsValid = true,
                CreatedDate = new DateTime(),
                ModifiedDate = new DateTime()
            };
            paymentContext.Add(pay2);

            PaymentOrder pay3 = new PaymentOrder
            {
                PaymentOrderId = 3,
                BankName = "Scotiabank",
                PaymentMethod = "Flow",
                Amount = 85000,
                IsValid = true,
                CreatedDate = new DateTime(),
                ModifiedDate = new DateTime()
            };
            paymentContext.Add(pay3);

            paymentContext.SaveChanges();
        }

    }
}
