using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Extensions
{
    public static class LayerRegistration
    {
        public static void RegisterApplicationDependencies(this IServiceCollection services, IConfiguration configuration, Assembly assembly)
        {
            services.RegisterAutoMapper(assembly);
            services.RegisterMediatR(assembly);

            services.RegisterApplicationOptions(configuration);

            services.AddHttpContextAccessor();

        }
    }
}
