using Infrastructure.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Serilog.Context;
using System.Net;
using System.Text.Json;

namespace Infrastructure.Auth.ApiKey;

public class ApiKeyMiddleware : IMiddleware
{
    private readonly IConfiguration _configuration;

    public ApiKeyMiddleware(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context?.Request?.Path.Value.Contains("/swagger") == false 
            && context?.Request?.Path.Value.IndexOf("/healthz") == -1
            && context?.Request?.Path.Value.IndexOf("/ui/resources/") == -1)
        {
            if (!context.Request.Headers.TryGetValue(ApiKeyConstant.ApiKeyHeader, out var extractedApiKey))
            {
                
                string errorId = Guid.NewGuid().ToString();
                var errorResult = new ErrorResult
                {
                    Source = "Authenticate request use Api Key",
                    Exception = "Api Key was not provided",
                    ErrorId = errorId,
                    SupportMessage = string.Format("Provide the ErrorId {0} to the support team for further analysis.", errorId),
                    StatusCode = (int)HttpStatusCode.Unauthorized
                };
                errorResult.Messages.Add("Provide the Api Key to your request");

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResult));
                return;
            }

            var apiKey = _configuration.GetValue<string>(ApiKeyConstant.ApiKeyConfig_SecretKey);

            if (!apiKey.Equals(extractedApiKey))
            {
                string errorId = Guid.NewGuid().ToString();
                var errorResult = new ErrorResult
                {
                    Source = "Authenticate request use Api Key",
                    Exception = "Request unauthorized",
                    ErrorId = errorId,
                    SupportMessage = string.Format("Provide the ErrorId {0} to the support team for further analysis.", errorId),
                    StatusCode = (int)HttpStatusCode.Unauthorized
                };

                errorResult.Messages.Add("Unauthorized client");
                
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResult));
                return;
            }
        }

        await next(context);
    }
}
