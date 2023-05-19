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

namespace ESISA.Core.Application.Extensions.DIRegitrations
{
    public static class OptionsRegistration
    {
        public static void RegisterApplicationOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureTokenOptions(configuration);
            services.ConfigureDatabaseOptions(configuration);
        }
        //TODO DUZELT
        public static void ConfigureTokenOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TokenOptions>(accessTokenOptions =>
            {
                accessTokenOptions = NonInjectableOptionsTool.GetTokenOptions(configuration);
            });
        }

        public static void ConfigureDatabaseOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SqlServerDatabaseOptions>(databaseOptions =>
            {
                databaseOptions = NonInjectableOptionsTool.GetDatabaseOptions(configuration);
            });
        }
    }
}
