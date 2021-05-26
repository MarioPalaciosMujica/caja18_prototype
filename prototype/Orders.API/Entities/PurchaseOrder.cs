using System;
namespace Orders.API.Entities
{
    public class PurchaseOrder
    {
        public int PurchaseOrderId { get; set; }
        public string ClientName { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAmount { get; set; }
        public decimal TaxesAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
