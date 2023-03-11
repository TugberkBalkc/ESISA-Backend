using ESISA.Core.Application.Interfaces.Repositorie;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Interfaces.Repositories.Discount;
using ESISA.Core.Application.Interfaces.Repositories.Identity.AuthenticationAndAuthorization;
using ESISA.Core.Domain.Entities;
using ESISA.Infrastructure.Persistence.EntityFramework;
using ESISA.Infrastructure.Persistence.EntityFramework.Repositories;
using ESISA.Infrastructure.Persistence.EntityFramework.Repositories.Demand;
using ESISA.Infrastructure.Persistence.EntityFramework.Repositories.Identity.AuthenticationAndAuthorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Infrastructure.Persistence.Extensions.DIRegistrations
{
    public static class RepositoryRegistration
    {
        internal static void RegisterAddressDomainEntitiesRepositories(this IServiceCollection services)
        {
            //Addresses
            services.AddScoped<IAddressCommandRepository, EFAddressCommandRepository>();
            services.AddScoped<IAddressQueryRepository, EFAddressQueryRepository>();

            services.AddScoped<ICityCommandRepository, EFCityCommandRepository>();
            services.AddScoped<ICityQueryRepository, EFCityQueryRepository>();

            services.AddScoped<ICorporateCustomerAddressCommandRepository, EFCorporateCustomerAddressCommandRepository>();
            services.AddScoped<ICorporateCustomerAddressQueryRepository, EFCorporateCustomerAddressQueryRepository>();

            services.AddScoped<ICountryCommandRepository, EFCountryCommandRepository>();
            services.AddScoped<ICountryQueryRepository, EFCountryQueryRepository>();

            services.AddScoped<IDistrictCommandRepository, EFDistrictCommandRepository>();
            services.AddScoped<IDistrictQueryRepository, EFDistrictQueryRepository>();

            services.AddScoped<IIndividualCustomerAddressCommandRepository, EFIndividualCustomerAddressCommandRepository>();
            services.AddScoped<IIndividualCustomerAddressQueryRepository, EFIndividualCustomerAddressQueryRepository>();
            //End Of Addresses
        }

        public static void RegisterAdvertDomainEntitiesRepositories(this IServiceCollection services)
        {
            //Adverts
            services.AddScoped<IAdvertCommandRepository, EFAdvertCommandRepository>();
            services.AddScoped<IAdvertQueryRepository, EFAdvertQueryRepository>();

            services.AddScoped<IAdvertPhotoPathCommandRepository, EFAdvertPhotoPathCommandRepository>();
            services.AddScoped<IAdvertPhotoPathQueryRepository, EFAdvertPhotoPathQueryRepository>();

            services.AddScoped<ICorporateAdvertCommandRepository, EFCorporateAdvertCommandRepository>();
            services.AddScoped<ICorporateAdvertQueryRepository, EFCorporateAdvertQueryRepository>();

            services.AddScoped<IIndividualAdvertCommandRepository, EFIndividualAdvertCommandRepository>();
            services.AddScoped<IIndividualAdvertQueryRepository, EFIndividualAdvertQueryRepository>();

            services.AddScoped<ISwapAdvertCommandRepository, EFSwapAdvertCommandRepository>();
            services.AddScoped<ISwapAdvertQueryRepository, EFSwapAdvertQueryRepository>();

            services.AddScoped<ISwapAdvertSwapableCategoryCommandRepository, EFSwapAdvertSwapableCategoryCommandRepository>();
            services.AddScoped<ISwapAdvertSwapableCategoryQueryRepository, EFSwapAdvertSwapableCategoryQueryRepository>();

            services.AddScoped<ISwapAdvertSwapableProductCommandRepository, EFSwapAdvertSwapableProductCommandRepository>();
            services.AddScoped<ISwapAdvertSwapableProductQueryRepository, EFSwapAdvertSwapableProductQueryRepository>();

            services.AddScoped<IWholesaleAdvertCommandRepository, EFWholesaleAdvertCommandRepository>();
            services.AddScoped<IWholesaleAdvertQueryRepository, EFWholesaleAdvertQueryRepository>();
            //End Of Adverts
        }
        public static void RegisterCategoryDomainEntitiesRepositories(this IServiceCollection services)
        {
            //Categories
            services.AddScoped<ICategoryCommandRepository, EFCategoryCommandRepository>();
            services.AddScoped<ICategoryQueryRepository, EFCategoryQueryRepository>();

            services.AddScoped<ICategoryPhotoPathCommandRepository, EFCategoryPhotoPathCommandRepository>();
            services.AddScoped<ICategoryPhotoPathQueryRepository, EFCategoryPhotoPathQueryRepository>();
            //End Of Categories
        }

        public static void RegisterDiscountDomainEntitiesRepositories(this IServiceCollection services)
        {
            //Discounts
            services.AddScoped<IUpperOrderPriceDiscountCommandRepository, EFUpperOrderPriceDiscountCommandRepository>();
            services.AddScoped<IUpperOrderPriceDiscountQueryRepository, EFUpperOrderPriceDiscountQueryRepository>();

            services.AddScoped<IPurchaseQuantityDiscountCommandRepository, EFPurchaseQuantityDiscountCommandRepository>();
            services.AddScoped<IPurchaseQuantityDiscountQueryRepository, EFPurchaseQuantityDiscountQueryRepository>();
            //End Of Discounts
        }

        public static void RegisterEvaluationDomainEntitiesRepositories(this IServiceCollection services)
        {
            //Comments
            services.AddScoped<ICorporateCustomerWholesaleAdvertCommentCommandRepository, EFCorporateCustomerWholesaleAdvertCommentCommandRepository>();
            services.AddScoped<ICorporateCustomerWholesaleAdvertCommentQueryRepository, EFCorporateCustomerWholesaleAdvertCommentQueryRepository>();

            services.AddScoped<IIndividualCustomerCorporateAdvertCommentCommandRepository, EFIndividualCustomerCorporateAdvertCommentCommandRepository>();
            services.AddScoped<IIndividualCustomerCorporateAdvertCommentQueryRepository, EFIndividualCustomerCorporateAdvertCommentQueryRepository>();

            services.AddScoped<ICorporateCustomerCorporateDealerCommentCommandRepository, EFCorporateCustomerCorporateDealerCommentCommandRepository>();
            services.AddScoped<ICorporateCustomerCorporateDealerCommentQueryRepository, EFCorporateCustomerCorporateDealerCommentQueryRepository>();

            services.AddScoped<ICorporateCustomerWholesaleAdvertFavoriteCommandRepository, EFCorporateCustomerWholesaleAdvertFavoriteCommandRepository>();
            services.AddScoped<ICorporateCustomerWholesaleAdvertFavoriteQueryRepository, EFCorporateCustomerWholesaleAdvertFavoriteQueryRepository>();
            //End Of Comments


            //Favorites
            services.AddScoped<IIndividualCustomerCorporateAdvertFavoriteCommandRepository, EFIndividualCustomerCorporateAdvertFavoriteCommandRepository>();
            services.AddScoped<IIndividualCustomerCorporateAdvertFavoriteQueryRepository, EFIndividualCustomerCorporateAdvertFavoriteQueryRepository>();

            services.AddScoped<IIndividualCustomerIndividualAdvertFavoriteCommandRepository, EFIndividualCustomerIndividualAdvertFavoriteCommandRepository>();
            services.AddScoped<IIndividualCustomerIndividualAdvertFavoriteQueryRepository, EFIndividualCustomerIndividualAdvertFavoriteQueryRepository>();

            services.AddScoped<IIndividualCustomerIndividualDealerCommentCommandRepository, EFIndividualCustomerIndividualDealerCommentCommandRepository>();
            services.AddScoped<IIndividualCustomerIndividualDealerCommentQueryRepository, EFIndividualCustomerIndividualDealerCommentQueryRepository>();
            //End Of Favorites

            //Votes
            services.AddScoped<ICorporateCustomerWholesaleAdvertVoteCommandRepository, EFCorporateCustomerWholesaleAdvertVoteCommandRepository>();
            services.AddScoped<ICorporateCustomerWholesaleAdvertVoteQueryRepository, EFCorporateCustomerWholesaleAdvertVoteQueryRepository>();

            services.AddScoped<IIndividualCustomerCorporateAdvertVoteCommandRepository, EFIndividualCustomerCorporateAdvertVoteCommandRepository>();
            services.AddScoped<IIndividualCustomerCorporateAdvertVoteQueryRepository, EFIndividualCustomerCorporateAdvertVoteQueryRepository>();

            services.AddScoped<IIndividualCustomerIndividualDealerVoteCommandRepository, EFIndividualCustomerIndividualDealerVoteCommandRepository>();
            services.AddScoped<IIndividualCustomerIndividualDealerVoteQueryRepository, EFIndividualCustomerIndividualDealerVoteQueryRepository>();
            //End Of Votes
        }

        public static void RegisterIdentityDomainEntitiesRepositories(this IServiceCollection services)
        {
            //Authentication & Authorization
            services.AddScoped<IOperationClaimCommandRepository, EFOperationClaimCommandRepository>();
            services.AddScoped<IOperationClaimQueryRepository, EFOperationClaimQueryRepository>();

            services.AddScoped<IRoleCommandRepository, EFRoleCommandRepository>();
            services.AddScoped<IRoleQueryRepository, EFRoleQueryRepository>();

            services.AddScoped<IRoleOperationClaimCommandRepository, EFRoleOperationClaimCommandRepository>();
            services.AddScoped<IRoleOperationClaimQueryRepository, EFRoleOperationClaimQueryRepository>();

            services.AddScoped<IUserRefreshTokenCommandRepository, EFUserRefreshTokenCommandRepository>();
            services.AddScoped<IUserRefreshTokenQueryRepository, EFUserRefreshTokenQueryRepository>();

            services.AddScoped<IUserRoleCommandRepository, EFUserRoleCommandRepository>();
            services.AddScoped<IUserRoleQueryRepository, EFUserRoleQueryRepository>();
            //End Of Authentication & Authorization

            //Common
            services.AddScoped<ICustomerCommandRepository, EFCustomerCommandRepository>();
            services.AddScoped<ICustomerQueryRepository, EFCustomerQueryRepository>();

            services.AddScoped<IDealerCommandRepository, EFDealerCommandRepository>();
            services.AddScoped<IDealerQueryRepository, EFDealerQueryRepository>();

            services.AddScoped<IUserCommandRepository, EFUserCommandRepository>();
            services.AddScoped<IUserQueryRepository, EFUserQueryRepository>();
            //End Of Common

            //Customer
            services.AddScoped<ICorporateCustomerCommandRepository, EFCorporateCustomerCommandRepository>();
            services.AddScoped<ICorporateCustomerQueryRepository, EFCorporateCustomerQueryRepository>();

            services.AddScoped<IIndividualCustomerCommandRepository, EFIndividualCustomerCommandRepository>();
            services.AddScoped<IIndividualCustomerQueryRepository, EFIndividualCustomerQueryRepository>();
            //End Of Customer

            //Dealer
            services.AddScoped<ICorporateDealerCommandRepository, EFCorporateDealerCommandRepository>();
            services.AddScoped<ICorporateDealerQueryRepository, EFCorporateDealerQueryRepository>();

            services.AddScoped<IIndividualDealerCommandRepository, EFIndividualDealerCommandRepository>();
            services.AddScoped<IIndividualDealerQueryRepository, EFIndividualDealerQueryRepository>();
            //End Of Dealer
        }

        public static void RegisterOrderDomainEntitiesRepositories(this IServiceCollection services)
        {
            //Common
            services.AddScoped<ICompletedOrderCommandRepository, EFCompletedOrderCommandRepository>();
            services.AddScoped<ICompletedOrderQueryRepository, EFCompletedOrderQueryRepository>();

            services.AddScoped<IOrderCommandRepository, EFOrderCommandRepository>();
            services.AddScoped<IOrderQueryRepository, EFOrderQueryRepository>();

            services.AddScoped<IReturnedOrderCommandRepository, EFReturnedOrderCommandRepository>();
            services.AddScoped<IReturnedOrderQueryRepository, EFReturnedOrderQueryRepository>();
            //End Of Common

            //Corporate Advert
            services.AddScoped<ICorporateAdvertOrderItemCommandRepository, EFCorporateAdvertOrderItemCommandRepository>();
            services.AddScoped<ICorporateAdvertOrderItemQueryRepository, EFCorporateAdvertOrderItemQueryRepository>();

            services.AddScoped<IIndividualCustomerCorporateAdvertOrderCommandRepository, EFIndividualCustomerCorporateAdvertOrderCommandRepository>();
            services.AddScoped<IIndividualCustomerCorporateAdvertOrderQueryRepository, EFIndividualCustomerCorporateAdvertOrderQueryRepository>();
            //End Of Corporate Advert

            //Wholesale Advert
            services.AddScoped<ICorporateCustomerWholesaleAdvertOrderCommandRepository, EFCorporateCustomerWholesaleAdvertOrderCommandRepository>();
            services.AddScoped<ICorporateCustomerWholesaleAdvertOrderQueryRepository, EFCorporateCustomerWholesaleAdvertOrderQueryRepository>();

            services.AddScoped<IWholesaleAdvertOrderItemCommandRepository, EFWholesaleAdvertOrderItemCommandRepository>();
            services.AddScoped<IWholesaleAdvertOrderItemQueryRepository, EFWholesaleAdvertOrderItemQueryRepository>();
            //End Of Wholesale Advert
        }

        public static void RegisterPaymentDomainEntitiesRepositories(this IServiceCollection services)
        {
        }

        public static void RegisterProductDomainEntitiesRepositories(this IServiceCollection services)
        {
            //Product
            services.AddScoped<IBrandCommandRepository, EFBrandCommandRepository>();
            services.AddScoped<IBrandQueryRepository, EFBrandQueryRepository>();

            services.AddScoped<IBrandPhotoPathCommandRepository, EFBrandPhotoPathCommandRepository>();
            services.AddScoped<IBrandPhotoPathQueryRepository, EFBrandPhotoPathQueryRepository>();

            services.AddScoped<IProductCommandRepository, EFProductCommandRepository>();
            services.AddScoped<IProductQueryRepository, EFProductQueryRepository>();
            //End Of Product
        }

        public static void RegisterDemandDomainEntitiesRepositories(this IServiceCollection services)
        {
            //Demand
            services.AddScoped<IProductDemandCommandRepository, EFProductDemandCommandRepository>();
            services.AddScoped<IProductDemandQueryRepository, EFProductDemandQueryRepository>();

            services.AddScoped<ICategoryDemandCommandRepository, EFCategoryDemandCommandRepository>();
            services.AddScoped<ICategoryDemandQueryRepository, EFCategoryDemandQueryRepository>();

            services.AddScoped<IBrandDemandCommandRepository, EFBrandDemandCommandRepository>();
            services.AddScoped<IBrandDemandQueryRepository, EFBrandDemandQueryRepository>();
            //End Of Demand
        }
    }
}
