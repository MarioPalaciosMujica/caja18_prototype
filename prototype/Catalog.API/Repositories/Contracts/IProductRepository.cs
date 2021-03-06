using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Entities;

namespace Catalog.API.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<Product> GetById(int id);

        Task<IEnumerable<Product>> GetAll();

        Task<Product> Create(Product entity);

        Task<Product> Modify(Product entity);

        Task<bool> DeleteById(int id);
    }
}
