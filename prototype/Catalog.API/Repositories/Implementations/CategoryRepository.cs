using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Entities;
using Catalog.API.Repositories.Contracts;

namespace Catalog.API.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ICatalogContext _catalogContext;

        public CategoryRepository(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
        }

        public Task<Category> Create(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Modify(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
