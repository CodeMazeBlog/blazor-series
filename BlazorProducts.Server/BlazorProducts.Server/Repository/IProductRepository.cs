using BlazorProducts.Server.Paging;
using Entities.Models;
using Entities.RequestParameters;
using System.Threading.Tasks;

namespace BlazorProducts.Server.Repository
{
    public interface IProductRepository
    {
        Task<PagedList<Product>> GetProducts(ProductParameters productParameters);
        Task CreateProduct(Product product);
    }
}
