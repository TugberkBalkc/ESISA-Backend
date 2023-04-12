using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Rules.BusinessRules.Common;
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
            services.AddScoped<AdressBusinessRules>();

            services.AddScoped<IndividualCustomerAddressBusinessRules>();

            services.AddScoped<ProductBusinessRules>();
            services.AddScoped<ProductDemandBusinessRules>();   

            services.AddScoped<CategoryBusinessRules>();
            services.AddScoped<CategoryDemandBusinessRules>();

            services.AddScoped<CityBusinessRules>();
            services.AddScoped<CountryBusinessRules>();

            services.AddScoped<DistrictBusinessRules>();

            services.AddScoped<UserBusinessRules>();
            services.AddScoped<CustomerBusinessRules>();

            services.AddScoped<BrandBusinessRules>();
            services.AddScoped<BrandDemandBusinessRules>(); 

            services.AddScoped<RoleBusinessRules>();
            services.AddScoped<OperationClaimBusinessRules>();
            services.AddScoped<RoleOperationClaimBusinessRules>();

            services.AddScoped<IndividualCustomerAddressBusinessRules>();

            services.AddScoped<IndividualStarterBusinessRules>();
            services.AddScoped<CorporateCustomerBusinessRules>();
            services.AddScoped<CorporateDealerBusinessRules>();
        }
    }
}
