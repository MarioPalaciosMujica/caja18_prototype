using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Catalog.API.Data;
using Catalog.API.Entities;
using Catalog.API.Repositories.Contracts;

namespace Catalog.API.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CatalogContext _catalogContext;

        public CategoryRepository(CatalogContext catalogContext)
        {
            _catalogContext = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
        }

        public async Task<Category> Create(Category entity)
        {
            await _catalogContext.Categories.AddAsync(entity);
            await _catalogContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteById(int id)
        {
            Category entity = await _catalogContext.Categories.FindAsync(id);
            _catalogContext.Categories.Remove(entity);
            await _catalogContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _catalogContext
                .Categories
                .Include(x => true)
                .ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _catalogContext
                .Categories
                .Include(cat => cat.CategoryId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Category> Modify(Category entity)
        {
            _catalogContext.Categories.Update(entity);
            await _catalogContext.SaveChangesAsync();
            return entity;
        }
    }
}
