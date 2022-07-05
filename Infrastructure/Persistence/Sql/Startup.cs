using Application.Common.Persistence.Sql;
using Infrastructure.Persistence.Sql.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Sql;

internal static class Startup
{
    private static readonly ILogger _logger = Log.ForContext(typeof(Startup));

    internal static IServiceCollection AddSqlPersistence(this IServiceCollection services, IConfiguration config)
    {
        var settings = config.GetSection("DatabaseSettings:Sql").Get<SqlSetting>();

        return services.AddSingleton<DbContext>(x => new DbContext(settings.ConnectionString))
            .AddScoped<IZoneRepository, ZoneRepository>();
    }
}
