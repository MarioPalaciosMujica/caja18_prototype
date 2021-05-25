using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Entities;
using Catalog.API.Repositories.Contracts;

namespace Catalog.API.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _catalogContext;

        public ProductRepository(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
        }

        public Task<Product> Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Modify(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
