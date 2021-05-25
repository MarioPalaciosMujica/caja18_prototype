using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Models;
using Catalog.API.Repositories.Contracts;
using Catalog.API.Services.Contracts;
using AutoMapper;

namespace Catalog.API.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<ProductModel> Create(ProductModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductModel>> GetByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> GetById(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> Modify(ProductModel model)
        {
            throw new NotImplementedException();
        }
    }
}
