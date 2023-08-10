using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CacheService
{
    public interface ICacheService
    {
        Task<string> Get( string key);
        Task Set(object? entity, string key);
        Task Remove(string name);
        Task<List<Product>> MakeFakeProductsData();
    }
}
