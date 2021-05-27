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
                IsValid = true,
                CreatedDate = new DateTime(),
                ModifiedDate = new DateTime()
            };
            paymentContext.Add(pay3);

            paymentContext.SaveChanges();
        }

    }
}
