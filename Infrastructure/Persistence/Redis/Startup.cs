using EasyCaching.Serialization.SystemTextJson.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Redis;

internal static class Startup
{
    internal static IServiceCollection AddRedisPersistence(this IServiceCollection services, IConfiguration config)
    {
        var settings = config.GetSection("DatabaseSettings:Redis").Get<RedisSetting>();

        if (settings != null)
        {
            services.AddEasyCaching(options =>
                {
                    options.WithSystemTextJson("json"); // Store as JSON, so we don't need to mark everything with [Serializable]

                    options.UseRedis(config =>
                    {
                        config.DBConfig.Endpoints.Add(new EasyCaching.Core.Configurations.ServerEndPoint(settings.Host, settings.Port));
                        config.DBConfig.Database = settings.Database;
                        config.DBConfig.Password = settings.Password;
                        config.SerializerName = "json";
                    }, settings.Name);

                });
        }

        return services;
    }
}
