using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orders.API.Entities;
using Orders.API.Models;
using Orders.API.Services.Contracts;

namespace Orders.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly IPurchaseOrderService _purchaseOrderService;
        private readonly IMapper _mapper;

        public PurchaseOrderController(IPurchaseOrderService purchaseOrderService, IMapper mapper)
        {
            _purchaseOrderService = purchaseOrderService ?? throw new ArgumentNullException(nameof(purchaseOrderService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("[action]/{id}", Name = "GetPurchaseOrderById")]
        [ProducesResponseType(typeof(PurchaseOrderModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PurchaseOrderModel>> GetPurchaseOrderById(int id)
        {
            PurchaseOrder entity = await _purchaseOrderService.GetById(id);
            return Ok(_mapper.Map<PurchaseOrderModel>(entity));
        }

        [HttpGet]
        [Route("GetAllPurchaseOrders")]
        [ProducesResponseType(typeof(IEnumerable<PurchaseOrderModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerator<PurchaseOrderModel>>> GetAllPurchaseOrders()
        {
            IEnumerable<PurchaseOrder> entities = await _purchaseOrderService.GetAll();
            return Ok(_mapper.Map<IEnumerable<PurchaseOrderModel>>(entities));
        }

        [HttpPost]
        [Route("CreatePurchaseOrder")]
        [ProducesResponseType(typeof(PurchaseOrderModel), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<PurchaseOrderModel>> CreatePurchaseOrder([FromBody] PurchaseOrderModel model)
        {
            PurchaseOrder entity = await _purchaseOrderService.Create(_mapper.Map<PurchaseOrder>(model));
            return Ok(_mapper.Map<PurchaseOrderModel>(entity));
        }

        [HttpDelete]
        [Route("[action]/{id}", Name = "DeletePurchaseOrder")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeletePurchaseOrder(int id)
        {
            return Ok(await _purchaseOrderService.DeleteById(id));
        }
    }
}
