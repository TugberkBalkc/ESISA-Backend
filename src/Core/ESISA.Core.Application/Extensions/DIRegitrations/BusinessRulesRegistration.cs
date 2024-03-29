﻿using ESISA.Core.Application.Rules.BusinessRules;
using ESISA.Core.Application.Rules.BusinessRules.Common;
using ESISA.Core.Domain.Entities;
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
            services.AddScoped<AddressBusinessRules>();

            services.AddScoped<IndividualCustomerAddressBusinessRules>();

            services.AddScoped<ProductBusinessRules>();
            services.AddScoped<ProductDemandBusinessRules>();   

            services.AddScoped<CategoryBusinessRules>();
            services.AddScoped<CategoryDemandBusinessRules>();

            services.AddScoped<CityBusinessRules>();
            services.AddScoped<CountryBusinessRules>();

            services.AddScoped<DistrictBusinessRules>();

            services.AddScoped<EvaluationBusinessRules>();

            services.AddScoped<UserBusinessRules>();
            services.AddScoped<CustomerBusinessRules>();

            services.AddScoped<BrandBusinessRules>();
            services.AddScoped<BrandDemandBusinessRules>(); 

            services.AddScoped<RoleBusinessRules>();
            services.AddScoped<UserRoleBusinessRules>();
            services.AddScoped<OperationClaimBusinessRules>();
            services.AddScoped<RoleOperationClaimBusinessRules>();

            services.AddScoped<IndividualCustomerAddressBusinessRules>();

            services.AddScoped<IndividualStarterBusinessRules>();
            services.AddScoped<CorporateCustomerBusinessRules>();
            services.AddScoped<CorporateDealerBusinessRules>();

            services.AddScoped<IndividualAdvertBusinessRules>();
            services.AddScoped<CorporateAdvertBusinessRules>();
            services.AddScoped<WholesaleAdvertBusinessRules>();

            services.AddScoped<PhotoPathBusinessRules>();

            services.AddScoped<SwapAdvertBusinessRules>();
        }
    }
}