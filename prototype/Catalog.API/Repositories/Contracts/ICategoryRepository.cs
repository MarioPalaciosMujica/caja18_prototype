using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Entities;

namespace Catalog.API.Repositories.Contracts
{
    public interface ICategoryRepository
    {
        Task<Category> GetById(int id);

        Task<IEnumerable<Category>> GetAll();

        Task<Category> Create(Category entity);

        Task<Category> Modify(Category entity);

        Task<bool> DeleteById(int id);
    }
}
