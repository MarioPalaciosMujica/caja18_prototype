using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Payments.API.Entities;
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
        private readonly IMapper _mapper;

        public PaymentOrderController(IPaymentOrderService paymentOrderService, IMapper mapper)
        {
            _paymentOrderService = paymentOrderService ?? throw new ArgumentNullException(nameof(paymentOrderService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("[action]/{id}", Name = "GetPaymentOrderById")]
        [ProducesResponseType(typeof(PaymentOrderModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaymentOrderModel>> GetPaymentOrderById(int id)
        {
            PaymentOrder entity = await _paymentOrderService.GetById(id);
            return Ok(_mapper.Map<PaymentOrderModel>(entity));
        }

        [HttpGet]
        [Route("GetAllPaymentOrders")]
        [ProducesResponseType(typeof(IEnumerable<PaymentOrderModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<PaymentOrderModel>>> GetAllPaymentOrders()
        {
            IEnumerable<PaymentOrder> entities = await _paymentOrderService.GetAll();
            return Ok(_mapper.Map<IEnumerable<PaymentOrderModel>>(entities));
        }

        [HttpPost]
        [Route("CreatePaymentOrder")]
        [ProducesResponseType(typeof(PaymentOrderModel), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<PaymentOrderModel>> CreatePaymentOrder([FromBody] PaymentOrderModel model)
        {
            PaymentOrder entity = await _paymentOrderService.Create(_mapper.Map<PaymentOrder>(model));
            return Ok(_mapper.Map<PaymentOrderModel>(entity));
        }

        [HttpPut]
        [Route("ModifyPaymentOrder")]
        [ProducesResponseType(typeof(PaymentOrderModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaymentOrderModel>> ModifyPaymentOrder([FromBody] PaymentOrderModel model)
        {
            PaymentOrder entity = await _paymentOrderService.Modify(_mapper.Map<PaymentOrder>(model));
            return Ok(_mapper.Map<PaymentOrderModel>(entity));
        }

        [HttpDelete]
        [Route("[action]/{id}", Name = "DeletePaymentOrder")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeletePaymentOrder(int id)
        {
            return Ok(await _paymentOrderService.DeleteById(id));
        }

    }
}
