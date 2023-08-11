using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CacheService
{
    public interface ICacheService
    {
        Task<T> Get<T>( string key);
        //Task<List<T>> GetList<T>( string key);
        Task Set<T>(T? entity, string key);
        Task Remove(string name);
        Task<List<Product>> MakeFakeProductsData(Product? product);
        Task<List<Product>> MakeFakeProductsData();
    }
}
