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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        [HttpGet]
        [Route("{id}", Name = "GetById")]
        [ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CategoryModel>> GetById(int id)
        {
            return Ok(await _categoryService.GetById(id));
        }

        [HttpGet]
        [Route(null, Name = "GetAll")]
        [ProducesResponseType(typeof(IEnumerable<ProductModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetAll()
        {
            return Ok(await _categoryService.GetAll());
        }

        [HttpPost]
        [Route(null, Name = "Create")]
        [ProducesResponseType(typeof(CategoryModel), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<CategoryModel>> Create([FromBody] CategoryModel model)
        {
            return Ok(await _categoryService.Create(model));
        }

        [HttpPut]
        [Route(null, Name = "Modify")]
        [ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CategoryModel>> Modify([FromBody] CategoryModel model)
        {
            return Ok(await _categoryService.Modify(model));
        }

        [HttpDelete]
        [Route("{id}", Name = "Delete")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return Ok(await _categoryService.DeleteById(id));
        }

    }
}
