using DNIC.Common.Cache;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Common.Infrastructure.DependencyManagement
{
    public static class DependencyInjectionConfig
    {
        public static void Inject(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<PerRequestCacheManager>();
            services.Configure<RedisOptions>(configuration.GetSection("RedisOptions"));
            //cache
            var redisEnable = configuration.GetValue<bool>("RedisOptions:Enable");
            if (redisEnable)
            {
                services.AddDistributedRedisCache(options =>
                {
                    options.Configuration = configuration.GetValue<string>("RedisOptions:Configration");
                    options.InstanceName = configuration.GetValue<string>("RedisOptions:InstanceName");
                });
                services.AddScoped<IRedisConnectionWrapper, RedisConnectionWrapper>();
                services.AddScoped<ICacheManager, DistributeCacheManager>();
            }
            else
            {
                services.AddMemoryCache();
            }
        }
    }
}
