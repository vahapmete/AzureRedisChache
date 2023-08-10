using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Core.CacheService
{
    public class RedisService: ICacheService
    {
        private readonly IDistributedCache _distributedCache;

        public RedisService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }


        public async Task<string> Get(string key)
        {
            try
            {
                
                string? cachedObjects = await _distributedCache.GetStringAsync(key);
                
                
                return cachedObjects;
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Set(object? obj, string key)
        {
            try
            {
                await _distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(obj));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task Remove(string key)
        {
            try
            {
                await _distributedCache.RemoveAsync(key);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<List<Product>> MakeFakeProductsData()
        {
            await Remove("products");
            List<Product> products = new()
            {
                new Product(){
                    Id = "1",
                    Name = "Product1",
                    Price = 43
                },
                new Product(){
                    Id = "2",
                    Name = "Product2",
                    Price = 43
                },
                new Product(){
                    Id = "3",
                    Name = "Product3",
                    Price = 43
                }, new Product(){
                    Id = "4",
                    Name = "Product4",
                    Price = 43
                },
            };
            return products;
        }
    }
}
