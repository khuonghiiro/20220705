using Application.Common.Persistence.Sql;
using Domain.Configurations.General;
using Domain.Configurations.Home;
using Infrastructure.Persistence.Sql.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataUsage;

internal static class Startup
{
    internal static IServiceCollection AddDataUsage(this IServiceCollection services, IConfiguration config)
    {
        var settings = config.GetSection("Configurations:HighLight").Get<HighLight>();

        return null;
    }
}
