using BlazorProducts.Server.Paging;
using Entities.Models;
using Entities.RequestParameters;
using System;
using System.Threading.Tasks;

namespace BlazorProducts.Server.Repository
{
    public interface IProductRepository
    {
        Task<PagedList<Product>> GetProducts(ProductParameters productParameters);
        Task CreateProduct(Product product);
        Task<Product> GetProduct(Guid id);
        Task UpdateProduct(Product product, Product dbProduct);
        Task DeleteProduct(Product product);
    }
}
