using ESISA.Infrastructure.Persistence.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Infrastructure.Persistence.Extensions.DIRegistrations
{
    public static class DbContextRegistration
    {
        internal static void RegisterDbContext(this IServiceCollection services, String connectionString)
        {
            services.AddDbContext<ESISADbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
