﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Models;

namespace Catalog.API.Services.Contracts
{
    public interface IProductService
    {
        Task<ProductModel> GetById(int id);

        Task<IEnumerable<ProductModel>> GetAll();

        Task<ProductModel> Create(ProductModel model);

        Task<ProductModel> Modify(ProductModel model);

        Task<bool> DeleteById(int id);
    }
}
