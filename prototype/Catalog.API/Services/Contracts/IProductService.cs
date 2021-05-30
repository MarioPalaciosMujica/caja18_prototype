using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Entities;
using Catalog.API.Models;

namespace Catalog.API.Services.Contracts
{
    public interface IProductService
    {
        Task<Product> GetById(int id);

        Task<IEnumerable<Product>> GetAll();

        Task<Product> Create(Product entity);

        Task<Product> Modify(Product entity);

        Task<bool> DeleteById(int id);
    }
}
