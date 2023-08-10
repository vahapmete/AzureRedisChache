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
            var cache = await _cacheService.Get("products");
            if (!string.IsNullOrEmpty(cache))
            {
                products = JsonConvert.DeserializeObject<List<Product>>(cache);

            }
            else
            {
                products = await _cacheService.MakeFakeProductsData();
                await _cacheService.Set(products, "products");
            }
            return Ok(products);
        }


    }
}
