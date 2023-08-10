using Core.CacheService;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Core
{
    public static class ServiceRegistration
    {
        public static void AddCoreServices(this IServiceCollection serviceCollection)
        {
            
            serviceCollection
                .AddScoped<ICacheService, RedisService>()
                .AddStackExchangeRedisCache(options => options.Configuration = "azureforredis.redis.cache.windows.net:6380,password=ky4HIiV8n7QawJtw0pd5ISyla0J1yx63OAzCaJIRw0g=,ssl=True,abortConnect=False");
            
        }

        

    }
}