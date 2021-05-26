using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Catalog.API.Entities;
using Catalog.API.Models;
using Catalog.API.Repositories.Contracts;
using Catalog.API.Services.Contracts;

namespace Catalog.API.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CategoryModel> Create(CategoryModel model)
        {
            Category entity = await _categoryRepository.Create(_mapper.Map<Category>(model));
            return _mapper.Map<CategoryModel>(entity);
        }

        public async Task<bool> DeleteById(int id)
        {
            Category entity = await _categoryRepository.GetById(id);
            if(entity != null)
            {
                return await _categoryRepository.DeleteById(id);
            }
            else
            {
                return false;
            }
            
        }

        public async Task<IEnumerable<CategoryModel>> GetAll()
        {
            IEnumerable<Category> entities = await _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryModel>>(entities);
        }

        public async Task<CategoryModel> GetById(int id)
        {
            Category entity = await _categoryRepository.GetById(id);
            return _mapper.Map<CategoryModel>(entity);
        }

        public async Task<CategoryModel> Modify(CategoryModel model)
        {
            Category entity = await _categoryRepository.GetById(model.CategoryId);
            if(entity != null)
            {
                entity = _mapper.Map<Category>(model);
                entity.ModifiedDate = new DateTime();
                return _mapper.Map<CategoryModel>(await _categoryRepository.Modify(entity));
            }
            else
            {
                return null;
            }
        }
    }
}
