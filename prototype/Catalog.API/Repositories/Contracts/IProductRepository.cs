using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Entities;

namespace Catalog.API.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<Product> GetById(int productId);

        Task<IEnumerable<Product>> GetAll();

        Task<IEnumerable<Product>> GetByCategoryId(int categoryId);

        Task<Product> Create(Product entity);

        Task<Product> Modify(Product entity);

        Task<bool> DeleteById(int id);
    }
}
