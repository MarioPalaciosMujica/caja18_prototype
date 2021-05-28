using System;
namespace Purchase.Aggregator.Models
{
    public class PaymentInputModel
    {
        public string ClientName { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int PaymentOrderId { get; set; }
    }
}
