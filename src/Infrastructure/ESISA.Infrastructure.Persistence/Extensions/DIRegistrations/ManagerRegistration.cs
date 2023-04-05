using ESISA.Core.Application.Interfaces.Services.Authentications;
using ESISA.Infrastructure.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Infrastructure.Persistence.Extensions.DIRegistrations
{
    internal static class ManagerRegistration
    {
        internal static void RegisterManagers(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationManager>();
        }
    }
}
