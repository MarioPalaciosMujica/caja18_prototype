using System;
using AutoMapper;
using Catalog.API.Entities;
using Catalog.API.Models;

namespace Catalog.API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            MapperConfiguration mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Product, ProductModel>();
                config.CreateMap<ProductModel, Product>();

                config.CreateMap<Category, CategoryModel>();
                config.CreateMap<CategoryModel, Category>();
            });
            return mappingConfig;
        }
    }
}
