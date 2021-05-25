using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Catalog.API.Data;
using Catalog.API.Entities;
using Catalog.API.Repositories.Contracts;

namespace Catalog.API.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogContext _catalogContext;

        public ProductRepository(CatalogContext catalogContext)
        {
            _catalogContext = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
        }

        public async Task<Product> Create(Product entity)
        {
            await _catalogContext.Products.AddAsync(entity);
            await _catalogContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteById(int id)
        {
            Product entity = await _catalogContext.Products.FindAsync(id);
            _catalogContext.Products.Remove(entity);
            await _catalogContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _catalogContext
                .Products
                .Include(prod => true)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByCategoryId(int categoryId)
        {
            return await _catalogContext
                .Products
                .Include(prod => prod.Category.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _catalogContext
                .Products
                .Include(prod => prod.ProductId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Product> Modify(Product entity)
        {
            _catalogContext.Products.Update(entity);
            await _catalogContext.SaveChangesAsync();
            return entity;
        }
    }
}
