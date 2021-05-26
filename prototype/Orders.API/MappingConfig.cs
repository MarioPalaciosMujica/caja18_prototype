using System;
using AutoMapper;
using Orders.API.Entities;
using Orders.API.Models;

namespace Orders.API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            MapperConfiguration mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<PurchaseOrder, PurchaseOrderModel>();
                config.CreateMap<PurchaseOrderModel, PurchaseOrder>();
            });
            return mappingConfig;
        }
    }
}
