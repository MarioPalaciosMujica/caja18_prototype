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
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpGet]
        [Route("{id}", Name = "GetById")]
        [ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductModel>> GetById(int id)
        {
            return Ok(await _productService.GetById(id));
        }

        [HttpGet]
        [Route("{categoryId}", Name = "GetByCategoryId")]
        [ProducesResponseType(typeof(IEnumerable<ProductModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetByCategoryId(int categoryId)
        {
            return Ok(await _productService.GetByCategoryId(categoryId));
        }

        [HttpGet]
        [Route(null, Name = "GetAll")]
        [ProducesResponseType(typeof(IEnumerable<ProductModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetAll()
        {
            return Ok(await _productService.GetAll());
        }

        [HttpPost]
        [Route(null, Name = "Create")]
        [ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<ProductModel>> Create([FromBody] ProductModel model)
        {
            return Ok(await _productService.Create(model));
        }

        [HttpPut]
        [Route(null, Name = "Modify")]
        [ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductModel>> Modify([FromBody] ProductModel model)
        {
            return Ok(await _productService.Modify(model));
        }

        [HttpDelete]
        [Route("{id}", Name = "Delete")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return Ok(await _productService.DeleteById(id));
        }

    }
}
