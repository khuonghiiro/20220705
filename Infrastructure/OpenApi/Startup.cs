using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NJsonSchema.Generation.TypeMappers;
using NSwag;
using NSwag.Generation.Processors.Security;
using ZymLabs.NSwag.FluentValidation;

namespace Infrastructure.OpenApi;

internal static class Startup
{
    internal static IServiceCollection AddOpenApiDocumentation(this IServiceCollection services, IConfiguration config)
    {
        var settings = config.GetSection(nameof(SwaggerSettings)).Get<SwaggerSettings>();
        if (settings.Enable)
        {
            services.AddVersionedApiExplorer(o => o.SubstituteApiVersionInUrl = true);
            services.AddEndpointsApiExplorer();
            services.AddOpenApiDocument((document, serviceProvider) =>
            {
                document.PostProcess = doc =>
                {
                    doc.Info.Title = settings.Title;
                    doc.Info.Version = settings.Version;
                    doc.Info.Description = settings.Description;
                    doc.Info.Contact = new()
                    {
                        Name = settings.ContactName,
                        Email = settings.ContactEmail,
                        Url = settings.ContactUrl
                    };
                    doc.Info.License = new()
                    {
                        Name = settings.LicenseName,
                        Url = settings.LicenseUrl
                    };
                };

                //document.AddSecurity(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                //{
                //    Name = "Authorization",
                //    Description = "Input your Bearer token to access this API",
                //    In = OpenApiSecurityApiKeyLocation.Header,
                //    Type = OpenApiSecuritySchemeType.Http,
                //    Scheme = JwtBearerDefaults.AuthenticationScheme,
                //    BearerFormat = "JWT",
                //});

                document.AddSecurity("ApiKey", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "secret_key",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Authenticate api use api key"
                });


                document.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("ApiKey"));

                document.TypeMappers.Add(new PrimitiveTypeMapper(typeof(TimeSpan), schema =>
                {
                    schema.Type = NJsonSchema.JsonObjectType.String;
                    schema.IsNullableRaw = true;
                    schema.Pattern = @"^([0-9]{1}|(?:0[0-9]|1[0-9]|2[0-3])+):([0-5]?[0-9])(?::([0-5]?[0-9])(?:.(\d{1,9}))?)?$";
                    schema.Example = "02:00:00";
                }));

                document.OperationProcessors.Add(new SwaggerHeaderAttributeProcessor());

                var fluentValidationSchemaProcessor = serviceProvider.CreateScope().ServiceProvider.GetService<FluentValidationSchemaProcessor>();
                document.SchemaProcessors.Add(fluentValidationSchemaProcessor);
            });
            services.AddScoped<FluentValidationSchemaProcessor>();
        }

        return services;
    }

    internal static IApplicationBuilder UseOpenApiDocumentation(this IApplicationBuilder app, IConfiguration config)
    {
        if (config.GetValue<bool>("SwaggerSettings:Enable"))
        {
            app.UseOpenApi();
            app.UseSwaggerUi3(options =>
            {
                options.DefaultModelsExpandDepth = -1;
                options.DocExpansion = "none";
                options.TagsSorter = "alpha";
            });
        }

        return app;
    }
}
