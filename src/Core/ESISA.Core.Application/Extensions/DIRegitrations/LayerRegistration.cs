using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Extensions.DIRegitrations
{
    public static class LayerRegistration
    {
        public static void RegisterApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.RegisterAutoMapper(assembly);
            services.RegisterMediatR(assembly);

            services.RegisterMediatRPipelines();

            services.RegisterApplicationOptions(configuration);

            services.RegisterBusinessRules();

            services.AddHttpContextAccessor();

        }
    }
}
