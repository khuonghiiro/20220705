using Infrastructure.Auth.ApiKey;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Auth;

internal static class Startup
{
    internal static IServiceCollection AddApiKeyMiddleware(this IServiceCollection services, IConfiguration config)
    {
        var security = config.GetValue<bool>(ApiKeyConstant.ApiKeyConfig_Enable);
        if (security)
        {
            services.AddSingleton<ApiKeyMiddleware>();
        }

        return services;
    }
    internal static IApplicationBuilder UseApiKeyMiddleware(this IApplicationBuilder app, IConfiguration config)
    {
        var security = config.GetValue<bool>(ApiKeyConstant.ApiKeyConfig_Enable);
        if (security)
            app.UseMiddleware<ApiKeyMiddleware>();
        return app;
    }

}
