using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Catalog.API.Models;
using Catalog.API.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        [HttpGet]
        [Route("[action]/{id}", Name = "GetCategoryById")]
        [ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CategoryModel>> GetCategoryById(int id)
        {
            return Ok(await _categoryService.GetById(id));
        }

        [HttpGet]
        [Route("GetAllCategories")]
        [ProducesResponseType(typeof(IEnumerable<ProductModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetAllCategories()
        {
            return Ok(await _categoryService.GetAll());
        }

        [HttpPost]
        [Route("CreateCategory")]
        [ProducesResponseType(typeof(CategoryModel), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<CategoryModel>> CreateCategory([FromBody] CategoryModel model)
        {
            return Ok(await _categoryService.Create(model));
        }

        [HttpPut]
        [Route("ModifyCategory")]
        [ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CategoryModel>> ModifyCategory([FromBody] CategoryModel model)
        {
            return Ok(await _categoryService.Modify(model));
        }

        [HttpDelete]
        [Route("[action]/{id}", Name = "DeleteCategory")]
        [ProducesResponseType(typeof(CategoryModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            return Ok(await _categoryService.DeleteById(id));
        }

    }
}
