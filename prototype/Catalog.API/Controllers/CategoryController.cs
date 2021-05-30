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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("[action]/{id}", Name = "GetCategoryById")]
        [ProducesResponseType(typeof(CategoryModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CategoryModel>> GetCategoryById(int id)
        {
            Category entity = await _categoryService.GetById(id);
            return Ok(_mapper.Map<CategoryModel>(entity));
        }

        [HttpGet]
        [Route("GetAllCategories")]
        [ProducesResponseType(typeof(IEnumerable<CategoryModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> GetAllCategories()
        {
            IEnumerable<Category> entities = await _categoryService.GetAll();
            return Ok(_mapper.Map<IEnumerable<Category>>(entities));
        }

        [HttpPost]
        [Route("CreateCategory")]
        [ProducesResponseType(typeof(CategoryModel), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<CategoryModel>> CreateCategory([FromBody] CategoryModel model)
        {
            Category entity = await _categoryService.Create(_mapper.Map<Category>(model));
            return Ok(_mapper.Map<CategoryModel>(entity));
        }

        [HttpPut]
        [Route("ModifyCategory")]
        [ProducesResponseType(typeof(CategoryModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CategoryModel>> ModifyCategory([FromBody] CategoryModel model)
        {
            Category entity = _mapper.Map<Category>(model);
            return Ok(await _categoryService.Modify(entity));
        }

        [HttpDelete]
        [Route("[action]/{id}", Name = "DeleteCategory")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            return Ok(await _categoryService.DeleteById(id));
        }

    }
}
