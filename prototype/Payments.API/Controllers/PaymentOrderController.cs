using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Payments.API.Models;
using Payments.API.Services.Contracts;

namespace Payments.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PaymentOrderController : ControllerBase
    {
        private readonly IPaymentOrderService _paymentOrderService;

        public PaymentOrderController(IPaymentOrderService paymentOrderService)
        {
            _paymentOrderService = paymentOrderService ?? throw new ArgumentNullException(nameof(paymentOrderService));
        }

        [HttpGet]
        [Route("[action]/{id}", Name = "GetPaymentOrderById")]
        [ProducesResponseType(typeof(PaymentOrderModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaymentOrderModel>> GetPaymentOrderById(int id)
        {
            return Ok(await _paymentOrderService.GetById(id));
        }

        [HttpGet]
        [Route("GetAllPaymentOrders")]
        [ProducesResponseType(typeof(IEnumerable<PaymentOrderModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<PaymentOrderModel>>> GetAllPaymentOrders()
        {
            return Ok(await _paymentOrderService.GetAll());
        }

        [HttpPost]
        [Route("CreatePaymentOrder")]
        [ProducesResponseType(typeof(PaymentOrderModel), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<PaymentOrderModel>> CreatePaymentOrder([FromBody] PaymentOrderModel model)
        {
            return Ok(await _paymentOrderService.Create(model));
        }

        [HttpPut]
        [Route("ModifyPaymentOrder")]
        [ProducesResponseType(typeof(PaymentOrderModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaymentOrderModel>> ModifyPaymentOrder([FromBody] PaymentOrderModel model)
        {
            return Ok(await _paymentOrderService.Modify(model));
        }

        [HttpDelete]
        [Route("[action]/{id}", Name = "DeletePaymentOrder")]
        [ProducesResponseType(typeof(PaymentOrderModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeletePaymentOrder(int id)
        {
            return Ok(await _paymentOrderService.DeleteById(id));
        }

    }
}
