using System;
using Orders.API.Entities;

namespace Orders.API.Data
{
    public class OrderSeed
    {
        public static void PopulateDatabase(OrderContext orderContext)
        {
            PurchaseOrder order1 = new PurchaseOrder()
            {
                PurchaseOrderId = 1,
                ClientName = "John Doe",
                ProductName = "Guitar",
                Quantity = 1,
                PriceAmount = 45000,
                TaxesAmount = 12000,
                TotalAmount = 67000,
                PaymentMethod = "WebPay",
                CreatedDate = new DateTime(),
                ModifyDate = new DateTime()
            };
            orderContext.PurchaseOrders.Add(order1);

            PurchaseOrder order2 = new PurchaseOrder()
            {
                PurchaseOrderId = 2,
                ClientName = "Jane Doe",
                ProductName = "Battery",
                Quantity = 1,
                PriceAmount = 55000,
                TaxesAmount = 22000,
                TotalAmount = 77000,
                PaymentMethod = "OnePay",
                CreatedDate = new DateTime(),
                ModifyDate = new DateTime()
            };
            orderContext.PurchaseOrders.Add(order2);

            PurchaseOrder order3 = new PurchaseOrder()
            {
                PurchaseOrderId = 3,
                ClientName = "Rick Sanchez",
                ProductName = "Laser",
                Quantity = 1,
                PriceAmount = 65000,
                TaxesAmount = 72000,
                TotalAmount = 87000,
                PaymentMethod = "PayPal",
                CreatedDate = new DateTime(),
                ModifyDate = new DateTime()
            };
            orderContext.PurchaseOrders.Add(order3);

            orderContext.SaveChanges();
        }


    }
}
