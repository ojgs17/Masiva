using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace RedisOgil
{
    public static class RedisExtension
    {
        static void Main(string[] args) { }
        public static IServiceCollection UseRedisCache(this IServiceCollection service, IConfiguration config)
        {
            if (!config.GetSection("Endpoint").Exists())
            {
                throw new ArgumentNullException("Algo salio mal en el archivo appsettings.json");
            }
            service.Configure<RedisSettings>(options => config.Bind(options));
            ConnectionMultiplexer cm = ConnectionMultiplexer.Connect(config.GetSection("Endpoint").Value);
            service.AddSingleton<IConnectionMultiplexer>(cm);
            service.AddScoped(typeof(IRedisService<>), typeof(RedisService<>));

            return service;
        }
    }
}
