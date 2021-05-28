using System;
using System.Threading.Tasks;
using Purchase.Aggregator.Models;
using Purchase.Aggregator.Services.Contracts;

namespace Purchase.Aggregator.Services.Implementations
{
    public class PaymentInputService : IPaymentInputService
    {
        private readonly ICatalogService _catalogService;
        private readonly IPaymentService _paymentService;
        private readonly IOrderService _orderService;

        public PaymentInputService(ICatalogService catalogService, IPaymentService paymentService, IOrderService orderService)
        {
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
            _paymentService = paymentService ?? throw new ArgumentNullException(nameof(paymentService));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        public async Task<PurchaseOrderModel> ProcessPayment(PaymentInputModel model)
        {
            ProductModel product = await _catalogService.GetProductById(model.ProductId);
            PaymentModel payment = await _paymentService.GetPaymentById(model.PaymentOrderId);

            PurchaseOrderModel purchaseOrder = new PurchaseOrderModel
            {
                PurchaseOrderId = 0,
                ClientName = model.ClientName,
                ProductName = product.Name,
                Quantity = model.Quantity,
                PriceAmount = product.PriceAmount * model.Quantity,
                TaxesAmount = 0,
                TotalAmount = 0,
                PaymentMethod = payment.PaymentMethod,
                CreatedDate = new DateTime(),
                ModifyDate = new DateTime()
            };

            return await _orderService.CreatePurchaseOrder(purchaseOrder);
        }


    }
}
