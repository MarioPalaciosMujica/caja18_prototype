using System;
namespace Payments.API.Models
{
    public class PaymentOrderModel
    {
        public int PaymentOrderId { get; set; }
        public string BankName { get; set; }
        public string PaymentMethod { get; set; }
        public bool IsValid { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
