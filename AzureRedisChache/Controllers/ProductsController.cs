using Core;
using Core.CacheService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AzureRedisCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ICacheService _cacheService;

        public ProductsController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            List<Product> products = new List<Product>();
            products  = await _cacheService.Get<List<Product>>("products");
            if (products!=null&&products.Count>0)
            {
                return Ok(products);

            }
            else
            {
                products = await _cacheService.MakeFakeProductsData();
                await _cacheService.Set<List<Product>>(products, "products");
            }
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            List<Product> products = await _cacheService.MakeFakeProductsData(product);
            return Ok(products);
        }


    }
}
