using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Models;
using Catalog.API.Repositories.Contracts;
using Catalog.API.Services.Contracts;
using AutoMapper;
using Catalog.API.Entities;

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

        public async Task<ProductModel> Create(ProductModel model)
        {
            Product entity = await _productRepository.Create(_mapper.Map<Product>(model));
            return _mapper.Map<ProductModel>(entity);
        }

        public async Task<bool> DeleteById(int id)
        {
            Product entity = await _productRepository.GetById(id);
            if(entity != null)
            {
                return await _productRepository.DeleteById(id);
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductModel>> GetAll()
        {
            IEnumerable<Product> entities = await _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductModel>>(entities);
        }

        public async Task<ProductModel> GetById(int id)
        {
            Product entity = await _productRepository.GetById(id);
            return _mapper.Map<ProductModel>(entity);
        }

        public async Task<ProductModel> Modify(ProductModel model)
        {
            Product entity = await _productRepository.GetById(model.ProductId);
            if(entity != null)
            {
                entity = _mapper.Map<Product>(model);
                entity.ModifiedDate = new DateTime();
                return _mapper.Map<ProductModel>(await _productRepository.Modify(entity));
            }
            else
            {
                return null;
            }
            
        }
    }
}
