using ESISA.Core.Application.Utilities.Configuration;
using ESISA.Infrastructure.Persistence.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Infrastructure.Persistence.Extensions.DIRegistrations
{
    public static class LayerRegistration
    {
        public static void RegisterPersistenceDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDbContext(NonInjectableOptionsTool.GetDatabaseOptions(configuration).ConnectionString);
            
            services.RegisterAddressDomainEntitiesRepositories();
            services.RegisterAdvertDomainEntitiesRepositories();
            services.RegisterCategoryDomainEntitiesRepositories();
            services.RegisterDiscountDomainEntitiesRepositories();
            services.RegisterEvaluationDomainEntitiesRepositories();
            services.RegisterIdentityDomainEntitiesRepositories();
            services.RegisterOrderDomainEntitiesRepositories();
            services.RegisterPaymentDomainEntitiesRepositories();
            services.RegisterProductDomainEntitiesRepositories();
        }
    }
}
