using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Entities;
using Catalog.API.Models;
using Catalog.API.Repositories.Contracts;
using Catalog.API.Services.Contracts;

namespace Catalog.API.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public async Task<Category> Create(Category entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            return await _categoryRepository.Create(entity);
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

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<Category> GetById(int id)
        {
            return await _categoryRepository.GetById(id);
        }

        public async Task<Category> Modify(Category entity)
        {
            Category oldEntity = await _categoryRepository.GetById(entity.CategoryId);
            if(oldEntity != null)
            {
                entity.CreatedDate = oldEntity.CreatedDate;
                entity.ModifiedDate = new DateTime();
                return await _categoryRepository.Modify(entity);
            }
            else
            {
                return null;
            }
        }
    }
}
