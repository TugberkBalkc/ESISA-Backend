﻿using ESISA.Infrastructure.Persistence.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Infrastructure.Persistence.Extensions
{
    public static class LayerRegistration
    {
        public static void RegisterPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
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
