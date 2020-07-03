using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorProducts.Server.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
    }
}
