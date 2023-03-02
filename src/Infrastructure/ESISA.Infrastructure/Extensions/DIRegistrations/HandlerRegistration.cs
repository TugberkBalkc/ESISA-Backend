using ESISA.Core.Application.Interfaces.Handlers;
using ESISA.Infrastructure.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Infrastructure.Extensions.DIRegistrations
{
    internal static class HandlerRegistration
    {
        internal static void RegisterHandlers(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, JwtTokenHandler>();
        }
    }
}
