using System.Threading.Tasks;
using BlazorProducts.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BlazorProducts.Server.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

		[HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _repo.GetProducts();
            return Ok(products);
        }
    }
}