using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Extensions
{
    internal static class MediatRRegistration
    {
        internal static void RegisterMediatR(this IServiceCollection services, Assembly assembly)
        {
            services.AddMediatR(assembly);
        }
    }
}
