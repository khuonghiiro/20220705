using HealthChecks.UI.Client;
using Infrastructure.Auth;
using Infrastructure.Caching;
using Infrastructure.Common;
using Infrastructure.Cors;
using Infrastructure.DataUsage;
using Infrastructure.Localization;
using Infrastructure.Mapping;
using Infrastructure.Middleware;
using Infrastructure.OpenApi;
using Infrastructure.Persistence.Redis;
using Infrastructure.Persistence.Sql;
using Infrastructure.SecurityHeaders;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        MapsterSettings.Configure();
        return services
            .AddApiVersioning()
            .AddCaching(config)
            .AddCorsPolicy(config)
            .AddApiKeyMiddleware(config)
            .AddExceptionMiddleware()
            .AddHealthCheck(config)
            .AddPOLocalization(config)
            .AddMediatR(Assembly.GetExecutingAssembly())
            .AddOpenApiDocumentation(config)
            .AddRedisPersistence(config)
            .AddSqlPersistence(config)
            .AddRequestLogging(config)
            .AddDataUsage(config)
            .AddRouting(options => options.LowercaseUrls = true)
            .AddServices();
    }

    private static IServiceCollection AddApiVersioning(this IServiceCollection services) =>
        services.AddApiVersioning(config =>
        {
            config.DefaultApiVersion = new ApiVersion(1, 0);
            config.AssumeDefaultVersionWhenUnspecified = true;
            config.ReportApiVersions = true;
        });



    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder builder, IConfiguration config) =>
        builder
            .UseRequestLocalization()
            .UseStaticFiles()
            .UseSecurityHeaders(config)
            .UseApiKeyMiddleware(config)
            .UseExceptionMiddleware()
            .UseRouting()
            .UseCorsPolicy()
            .UseAuthentication()
            .UseAuthorization()
            .UseRequestLogging(config)
            .UseOpenApiDocumentation(config);

    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.MapControllers();
        builder.MapHealthCheck();
        builder.MapHealthCheckUI();
        return builder;
    }

    private static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration config)
    {
        var sqlSetting = config.GetSection("DatabaseSettings:Sql").Get<SqlSetting>();
        var redisSetting = config.GetSection("DatabaseSettings:Redis").Get<RedisSetting>();

        var redisConnectionString = redisSetting.Host + ":" + redisSetting.Port + ",defaultDatabase=" + redisSetting.Database + (!string.IsNullOrEmpty(redisSetting.Password) ? ",password=" + redisSetting.Password : "");

        return services
            .AddHealthChecksUI(setupSettings: setup =>
            {
                setup.SetHeaderText("API App Genk - Health Checks Status");
                setup.AddHealthCheckEndpoint("database", "/healthz");
            })
            .AddInMemoryStorage()
            .Services
            .AddHealthChecks()
            .AddSqlServer(sqlSetting.ConnectionString)
            .AddRedis(redisConnectionString)
            .Services;
            
    }

    private static IEndpointConventionBuilder MapHealthCheck(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapHealthChecks("/healthz", new HealthCheckOptions
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

    private static IEndpointConventionBuilder MapHealthCheckUI(this IEndpointRouteBuilder endpoints) =>
        endpoints.MapHealthChecksUI(setup =>
        {
            setup.UIPath = "/healthz-ui"; // this is ui path in your browser
            setup.ApiPath = "/healthz-ui-api"; // the UI ( spa app )  use this path to get information from the store ( this is NOT the healthz path, is internal ui api )
        });
}
