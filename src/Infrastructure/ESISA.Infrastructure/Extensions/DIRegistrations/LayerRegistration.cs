using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Infrastructure.Extensions.DIRegistrations
{
    public static class LayerRegistration
    {
        public static void RegisterInfrastructureDependencies(this IServiceCollection services)
        {
            services.RegisterHandlers();
        }
    }
}
