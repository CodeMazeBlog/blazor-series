using System.Threading.Tasks;
using BlazorProducts.Server.Repository;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public async Task<IActionResult> Get([FromQuery] ProductParameters productParameters)
        {
            var products = await _repo.GetProducts(productParameters);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(products.MetaData));

            return Ok(products);
        }
    }
}