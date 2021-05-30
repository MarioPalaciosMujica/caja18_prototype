using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public PurchaseOrderController(IPurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderService = purchaseOrderService ?? throw new ArgumentNullException(nameof(purchaseOrderService));
        }

        [HttpGet]
        [Route("[action]/{id}", Name = "GetPurchaseOrderById")]
        [ProducesResponseType(typeof(PurchaseOrderModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PurchaseOrderModel>> GetPurchaseOrderById(int id)
        {
            return Ok(await _purchaseOrderService.GetById(id));
        }

        [HttpGet]
        [Route("GetAllPurchaseOrders")]
        [ProducesResponseType(typeof(PurchaseOrderModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerator<PurchaseOrderModel>>> GetAllPurchaseOrders()
        {
            return Ok(await _purchaseOrderService.GetAll());
        }

        [HttpPost]
        [Route("CreatePurchaseOrder")]
        [ProducesResponseType(typeof(PurchaseOrderModel), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<PurchaseOrderModel>> CreatePurchaseOrder([FromBody] PurchaseOrderModel model)
        {
            return Ok(await _purchaseOrderService.Create(model));
        }

        [HttpDelete]
        [Route("[action]/{id}", Name = "DeletePurchaseOrder")]
        [ProducesResponseType(typeof(PurchaseOrderModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeletePurchaseOrder(int id)
        {
            return Ok(await _purchaseOrderService.DeleteById(id));
        }
    }
}
