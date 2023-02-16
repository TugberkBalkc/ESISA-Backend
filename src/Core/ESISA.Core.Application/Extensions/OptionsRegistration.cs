using ESISA.Core.Application.Options.Authentication;
using ESISA.Core.Application.Options.Database;
using ESISA.Core.Application.Utilities.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Extensions
{
    public static class OptionsRegistration
    {
        public static void RegisterApplicationOptions(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureAccessTokenOptions(services, configuration);
            ConfigureRefreshTokenOptions(services, configuration);
            ConfigureDatabaseOptions(services, configuration);
        }

        private static void ConfigureAccessTokenOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AccessTokenOptions>(accessTokenOptions =>
            {
                accessTokenOptions = NonInjectableOptionsTool.GetAccessTokenOptions(configuration);
            });
        }

        private static void ConfigureRefreshTokenOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RefreshTokenOptions>(refreshTokenOptions =>
            {
                refreshTokenOptions = NonInjectableOptionsTool.GetRefreshTokenOptions(configuration);
            });
        }

        private static void ConfigureDatabaseOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SqlServerDatabaseOptions>(databaseOptions =>
            {
                databaseOptions = NonInjectableOptionsTool.GetDatabaseOptions(configuration);
            });
        }
    }
}
