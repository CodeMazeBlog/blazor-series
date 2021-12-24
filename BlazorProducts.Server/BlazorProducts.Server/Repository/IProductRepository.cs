using BlazorProducts.Server.Paging;
using Entities.Models;
using Entities.RequestFeatures;

namespace BlazorProducts.Server.Repository;

public interface IProductRepository
{
    Task<PagedList<Product>> GetProducts(ProductParameters productParameters);
}