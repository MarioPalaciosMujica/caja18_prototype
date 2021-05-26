using System;
using AutoMapper;
using Payments.API.Entities;
using Payments.API.Models;

namespace Payments.API
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            MapperConfiguration mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<PaymentOrder, PaymentOrderModel>();
                config.CreateMap<PaymentOrderModel, PaymentOrder>();
            });
            return mappingConfig;
        }
    }
}
