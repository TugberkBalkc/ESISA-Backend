using ESISA.Core.Application.Rules.BusinessRules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Extensions.DIRegitrations
{
    internal static class BusinessRulesRegistration
    {
        internal static void RegisterBusinessRules(this IServiceCollection services)
        {
            services.AddScoped<ProductBusinessRules>();
            services.AddScoped<ProductDemandBusinessRules>();   

            services.AddScoped<CategoryBusinessRules>();
            services.AddScoped<CategoryDemandBusinessRules>();
            
            services.AddScoped<BrandBusinessRules>();
            services.AddScoped<BrandDemandBusinessRules>(); 

        }
    }
}
