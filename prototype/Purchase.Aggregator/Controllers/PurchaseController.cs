using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Purchase.Aggregator.Models;
using Purchase.Aggregator.Services.Contracts;

namespace Purchase.Aggregator.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPaymentInputService _paymentInputService;

        public PurchaseController(IPaymentInputService paymentInputService)
        {
            _paymentInputService = paymentInputService ?? throw new ArgumentNullException(nameof(paymentInputService));
        }

        [HttpPost]
        [Route("ProcessPayment")]
        [ProducesResponseType(typeof(PurchaseOrderModel), (int)HttpStatusCode.Created)]
        public async Task<PurchaseOrderModel> ProcessPayment([FromBody] PaymentInputModel model)
        {
            string bearerToken = Request.Headers[HeaderNames.Authorization];
            return await _paymentInputService.ProcessPayment(model, bearerToken);
        }
    }
}
