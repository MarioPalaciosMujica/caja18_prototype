using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Catalog.API.Models;
using Catalog.API.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpGet]
        [Route("[action]/{id}", Name = "GetProductById")]
        [ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductModel>> GetProductById(int id)
        {
            return Ok(await _productService.GetById(id));
        }

        [HttpGet]
        [Route("GetAllProducts")]
        [ProducesResponseType(typeof(IEnumerable<ProductModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetAllProducts()
        {
            return Ok(await _productService.GetAll());
        }

        [HttpPost]
        [Route("CreateProduct")]
        [ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<ProductModel>> CreateProduct([FromBody] ProductModel model)
        {
            return Ok(await _productService.Create(model));
        }

        [HttpPut]
        [Route("ModifyProduct")]
        [ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductModel>> ModifyProduct([FromBody] ProductModel model)
        {
            return Ok(await _productService.Modify(model));
        }

        [HttpDelete]
        [Route("[action]/{id}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return Ok(await _productService.DeleteById(id));
        }

    }
}
