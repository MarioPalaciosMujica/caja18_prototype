using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Catalog.API.Entities;
using Catalog.API.Models;
using Catalog.API.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("[action]/{id}", Name = "GetProductById")]
        [ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductModel>> GetProductById(int id)
        {
            Product entity = await _productService.GetById(id);
            return Ok(_mapper.Map<ProductModel>(entity));
        }

        [HttpGet]
        [Route("GetAllProducts")]
        [ProducesResponseType(typeof(IEnumerable<ProductModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetAllProducts()
        {
            IEnumerable<Product> entities = await _productService.GetAll();
            return Ok(_mapper.Map<IEnumerable<ProductModel>>(entities));
        }

        [HttpPost]
        [Route("CreateProduct")]
        [ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<ProductModel>> CreateProduct([FromBody] ProductModel model)
        {
            Product entity = await _productService.Create(_mapper.Map<Product>(model));
            return Ok(_mapper.Map<ProductModel>(entity));
        }

        [HttpPut]
        [Route("ModifyProduct")]
        [ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductModel>> ModifyProduct([FromBody] ProductModel model)
        {
            Product entity = await _productService.Modify(_mapper.Map<Product>(model));
            return Ok(_mapper.Map<ProductModel>(entity));
        }

        [HttpDelete]
        [Route("[action]/{id}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return Ok(await _productService.DeleteById(id));
        }

    }
}
