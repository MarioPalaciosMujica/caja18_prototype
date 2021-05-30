using System;
using System.Threading.Tasks;
using Purchase.Aggregator.Models;

namespace Purchase.Aggregator.Services.Contracts
{
    public interface ICatalogService
    {
        Task<ProductModel> GetProductById(int id, string bearerToken);
    }
}
