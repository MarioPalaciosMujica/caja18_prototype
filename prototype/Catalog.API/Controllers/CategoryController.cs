using System;
using System.Net;
using System.Threading.Tasks;
using Catalog.API.Models;
using Catalog.API.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        [HttpPost]
        [ProducesResponseType(typeof(CategoryModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CategoryModel>> Create([FromBody] CategoryModel model)
        {
            return Ok(await _categoryService.Create(model));
        }

        [HttpGet]
        [Route("{id}", Name = "GetById")]
        [ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CategoryModel>> GetById(int id)
        {
            return Ok(await _categoryService.GetById(id));
        }

        
    }
}
