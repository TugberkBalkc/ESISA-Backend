using AutoMapper;
using ESISA.Core.Application.Dtos.Advert.SwapAdvert;
using ESISA.Core.Application.Features.MediatR.Commands.SwapAdverts.AddSwappableProduct;
using ESISA.Core.Application.Features.MediatR.Commands.SwapAdverts.AddPhoto;
using ESISA.Core.Application.Features.MediatR.Commands.SwapAdverts.AddSwappableCategory;
using ESISA.Core.Application.Features.MediatR.Commands.SwapAdverts.Create;
using ESISA.Core.Application.Features.MediatR.Commands.SwapAdverts.Update;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Mappings.Automapper
{
    public class SwapAdvertProfile : Profile
    {
        public SwapAdvertProfile()
        {

            this.CreateMap<CreateSwapAdvertCommandRequest, Advert>()
                .ForMember(e => e.Title, e => e.MapFrom(e => e.AdvertTitle))
                .ForMember(e => e.Description, e => e.MapFrom(e => e.AdvertDescription));

            this.CreateMap<CreateSwapAdvertCommandRequest, SwapAdvert>()
                .ForMember(e => e.IndividualDealerId, e => e.MapFrom(e => e.SwapAdvertIndividualDealerId))
                .ForMember(e => e.ProductId, e => e.MapFrom(e => e.SwapAdvertProductId))
                .ForMember(e => e.ProductConditionType, e => e.MapFrom(e => e.SwapAdvertProductConditionType));

            this.CreateMap<CreateSwapAdvertCommandRequest, SwapAdvertDto>()
                .ForMember(e => e.AdvertTitle, e => e.MapFrom(e => e.AdvertTitle))
                .ForMember(e => e.AdvertDescription, e => e.MapFrom(e => e.AdvertDescription))
                .ForMember(e => e.SwapAdvertIndividualDealerId, e => e.MapFrom(e => e.SwapAdvertIndividualDealerId))
                .ForMember(e => e.SwapAdvertProductId, e => e.MapFrom(e => e.SwapAdvertProductId))
                .ForMember(e => e.SwapAdvertProductConditionType, e => e.MapFrom(e => e.SwapAdvertProductConditionType));

            this.CreateMap<UpdateSwapAdvertCommandRequest, Advert>()
                .ForMember(e => e.Title, e => e.MapFrom(e => e.AdvertTitle))
                .ForMember(e => e.Description, e => e.MapFrom(e => e.AdvertDescription));

            this.CreateMap<UpdateSwapAdvertCommandRequest, SwapAdvert>()
            .ForMember(e => e.ProductConditionType, e => e.MapFrom(e => e.SwapAdvertProductConditionType));

            this.CreateMap<UpdateSwapAdvertCommandRequest, SwapAdvertDto>()
              .ForMember(e => e.AdvertTitle, e => e.MapFrom(e => e.AdvertTitle))
              .ForMember(e => e.AdvertDescription, e => e.MapFrom(e => e.AdvertDescription))
              .ForMember(e => e.SwapAdvertProductConditionType, e => e.MapFrom(e => e.SwapAdvertProductConditionType));

            this.CreateMap<AddSwappableCategoryCommandRequest, SwapAdvertSwapableCategory>()
                .ForMember(e => e.CategoryId, e => e.MapFrom(e => e.CategoryId))
                .ForMember(e => e.SwapAdvertId, e => e.MapFrom(e => e.SwapAdvertId));

            this.CreateMap<SwapAdvertSwapableCategory, SwapAdvertSwappableCategoryDto>()
               .ForMember(e=>e.SwapAdvertSwappableCategoryId, e=>e.MapFrom(e=>e.Id))
               .ForMember(e => e.SwapAdvertSwappableCategoryCreatedDate, e => e.MapFrom(e => e.CreatedDate))
               .ForMember(e => e.SwapAdvertSwappableCategoryModifiedDate, e => e.MapFrom(e => e.ModifiedDate))
               .ForMember(e => e.SwapAdvertSwappableCategoryIsDeleted, e => e.MapFrom(e => e.IsActive))
               .ForMember(e => e.SwapAdvertSwappableCategoryIsActive, e => e.MapFrom(e => e.IsDeleted))
               .ForMember(e => e.CategoryId, e => e.MapFrom(e => e.CategoryId))
               .ForMember(e => e.SwapAdvertId, e => e.MapFrom(e => e.SwapAdvertId));

            this.CreateMap<AddSwappableProductCommandRequest, SwapAdvertSwapableProduct>()
           .ForMember(e => e.ProductId, e => e.MapFrom(e => e.ProductId))
           .ForMember(e => e.SwapAdvertId, e => e.MapFrom(e => e.SwapAdvertId));

            this.CreateMap<SwapAdvertSwapableProduct, SwapAdvertSwappableProductDto>()
               .ForMember(e => e.SwapAdvertSwappableProductId, e => e.MapFrom(e => e.Id))
               .ForMember(e => e.SwapAdvertSwappableProductCreatedDate, e => e.MapFrom(e => e.CreatedDate))
               .ForMember(e => e.SwapAdvertSwappableProductModifiedDate, e => e.MapFrom(e => e.ModifiedDate))
               .ForMember(e => e.SwapAdvertSwappableProductIsDeleted, e => e.MapFrom(e => e.IsActive))
               .ForMember(e => e.SwapAdvertSwappableProductIsActive, e => e.MapFrom(e => e.IsDeleted))
               .ForMember(e => e.ProductId, e => e.MapFrom(e => e.ProductId))
               .ForMember(e => e.SwapAdvertId, e => e.MapFrom(e => e.SwapAdvertId));

            this.CreateMap<SwapAdvert, SwapAdvertDto>()
                .ForMember(e => e.AdvertId, e => e.MapFrom(e => e.AdvertId))
                .ForMember(e => e.AdvertTitle, e => e.MapFrom(e => e.Advert.Title))
                .ForMember(e => e.AdvertDescription, e => e.MapFrom(e => e.Advert.Description))
                .ForMember(e => e.IsSwapAdvertActive, e => e.MapFrom(e => e.IsActive))
                .ForMember(e => e.SwapAdvertId, e => e.MapFrom(e => e.Id))
                .ForMember(e => e.SwapAdvertIndividualDealerId, e => e.MapFrom(e => e.IndividualDealerId))
                .ForMember(e => e.SwapAdvertProductId, e => e.MapFrom(e => e.ProductId))
                .ForMember(e => e.SwapAdvertProductConditionType, e => e.MapFrom(e => e.ProductConditionType))
                .ForMember(e => e.SwapAdvertSwappableCategories, e => e.MapFrom(e => e.SwapAdvertSwapableCategories))
                .ForMember(e => e.SwapAdvertSwappableProducts, e => e.MapFrom(e => e.SwapAdvertSwapableProducts));

            this.CreateMap<SwapAdvert, SwapAdvertDetailsDto>()
                .ForMember(e => e.AdvertId, e => e.MapFrom(e => e.AdvertId))
                .ForMember(e => e.AdvertTitle, e => e.MapFrom(e => e.Advert.Title))
                .ForMember(e => e.AdvertDescription, e => e.MapFrom(e => e.Advert.Description))
                .ForMember(e => e.IsSwapAdvertActive, e => e.MapFrom(e => e.IsActive))
                .ForMember(e => e.SwapAdvertId, e => e.MapFrom(e => e.Id))
                .ForMember(e => e.SwapAdvertIndividualDealerId, e => e.MapFrom(e => e.IndividualDealerId))
                .ForMember(e => e.SwapAdvertIndividualDealerFirstName, e => e.MapFrom(e => e.IndividualDealer.Dealer.User.Customer.IndividualCustomer.FirstName))
                .ForMember(e => e.SwapAdvertIndividualDealerLastName, e => e.MapFrom(e => e.IndividualDealer.Dealer.User.Customer.IndividualCustomer.LastName))
                .ForMember(e => e.SwapAdvertProductId, e => e.MapFrom(e => e.ProductId))
                .ForMember(e => e.SwapAdvertProductName, e => e.MapFrom(e => e.Product.Name))
                .ForMember(e => e.SwapAdvertProductCategoryId, e => e.MapFrom(e => e.Product.CategoryId))
                .ForMember(e => e.SwapAdvertProductCategoryName, e => e.MapFrom(e => e.Product.Category.Name))
                .ForMember(e => e.SwapAdvertProductBrandId, e => e.MapFrom(e => e.Product.BrandId))
                .ForMember(e => e.SwapAdvertProductBrandName, e => e.MapFrom(e => e.Product.Brand.Name))
                .ForMember(e => e.SwapAdvertProductConditionType, e => e.MapFrom(e => e.ProductConditionType))
                     .ForMember(e => e.SwapAdvertSwappableCategories, e => e.MapFrom(e => e.SwapAdvertSwapableCategories))
                .ForMember(e => e.SwapAdvertSwappableProducts, e => e.MapFrom(e => e.SwapAdvertSwapableProducts));

            this.CreateMap<SwapAdvertSwapableCategory, SwapAdvertSwappableCategoryDto>()
                .ForMember(e => e.SwapAdvertSwappableCategoryId, e => e.MapFrom(e => e.Id))
                .ForMember(e => e.SwapAdvertSwappableCategoryCreatedDate, e => e.MapFrom(e => e.CreatedDate))
                .ForMember(e => e.SwapAdvertSwappableCategoryModifiedDate, e => e.MapFrom(e => e.ModifiedDate))
                .ForMember(e => e.SwapAdvertSwappableCategoryIsActive, e => e.MapFrom(e => e.IsActive))
                .ForMember(e => e.SwapAdvertId, e => e.MapFrom(e => e.SwapAdvertId))
                .ForMember(e => e.CategoryId, e => e.MapFrom(e => e.CategoryId));


            this.CreateMap<SwapAdvertSwapableCategory, SwapAdvertSwappableCategoryDetailsDto>()
                .ForMember(e => e.SwapAdvertSwappableCategoryId, e => e.MapFrom(e => e.Id))
                .ForMember(e => e.SwapAdvertSwappableCategoryCreatedDate, e => e.MapFrom(e => e.CreatedDate))
                .ForMember(e => e.SwapAdvertSwappableCategoryModifiedDate, e => e.MapFrom(e => e.ModifiedDate))
                .ForMember(e => e.SwapAdvertSwappableCategoryIsActive, e => e.MapFrom(e => e.IsActive))
                .ForMember(e => e.SwapAdvertId, e => e.MapFrom(e => e.SwapAdvertId))
                .ForMember(e => e.CategoryId, e => e.MapFrom(e => e.CategoryId))
                .ForMember(e => e.CategoryName, e => e.MapFrom(e => e.Category.Name));

            this.CreateMap<SwapAdvertSwapableProduct, SwapAdvertSwappableProductDto>()
                .ForMember(e => e.SwapAdvertSwappableProductId, e => e.MapFrom(e => e.Id))
                .ForMember(e => e.SwapAdvertSwappableProductCreatedDate, e => e.MapFrom(e => e.CreatedDate))
                .ForMember(e => e.SwapAdvertSwappableProductModifiedDate, e => e.MapFrom(e => e.ModifiedDate))
                .ForMember(e => e.SwapAdvertSwappableProductIsActive, e => e.MapFrom(e => e.IsActive))
                .ForMember(e => e.SwapAdvertId, e => e.MapFrom(e => e.SwapAdvertId))
                .ForMember(e => e.ProductId, e => e.MapFrom(e => e.ProductId));

            this.CreateMap<SwapAdvertSwapableProduct, SwapAdvertSwappableProductDetailsDto>()
                .ForMember(e => e.SwapAdvertSwappableProductId, e => e.MapFrom(e => e.Id))
                .ForMember(e => e.SwapAdvertSwappableProductCreatedDate, e => e.MapFrom(e => e.CreatedDate))
                .ForMember(e => e.SwapAdvertSwappableProductModifiedDate, e => e.MapFrom(e => e.ModifiedDate))
                .ForMember(e => e.SwapAdvertSwappableProductIsActive, e => e.MapFrom(e => e.IsActive))
                .ForMember(e => e.SwapAdvertId, e => e.MapFrom(e => e.SwapAdvertId))
                .ForMember(e => e.ProductId, e => e.MapFrom(e => e.ProductId))
                .ForMember(e => e.ProductName, e => e.MapFrom(e => e.Product.Name))
                .ForMember(e => e.ProductBrandId, e => e.MapFrom(e => e.Product.BrandId))
                .ForMember(e => e.ProductBrandName, e => e.MapFrom(e => e.Product.Brand.Name));
        }
    }
}
