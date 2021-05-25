using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Models;

namespace Catalog.API.Services.Contracts
{
    public interface ICategoryService
    {
        Task<CategoryModel> GetById(int id);

        Task<IEnumerable<CategoryModel>> GetAll();

        Task<CategoryModel> Create(CategoryModel model);

        Task<CategoryModel> Modify(CategoryModel model);

        Task<bool> DeleteById(int id);
    }
}
