using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Extensions.DIRegitrations
{
    internal static class AutoMapperRegistration
    {
        internal static void RegisterAutoMapper(this IServiceCollection services, Assembly assembly)
        {
            services.AddAutoMapper(assembly);
        }
    }
}
