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

        public async Task<Product> Create(Product entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            return await _productRepository.Create(entity);
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

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Product> GetById(int id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task<Product> Modify(Product entity)
        {
            Product oldEntity = await _productRepository.GetById(entity.ProductId);
            if(oldEntity != null)
            {
                entity.CreatedDate = oldEntity.CreatedDate;
                entity.ModifiedDate = new DateTime();
                return await _productRepository.Modify(entity);
            }
            else
            {
                return null;
            }
            
        }
    }
}
