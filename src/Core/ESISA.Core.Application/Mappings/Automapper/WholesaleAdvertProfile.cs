using AutoMapper;
using ESISA.Core.Application.Dtos.Advert.CorporateAdverts;
using ESISA.Core.Application.Dtos.Advert.IndividualAdvert;
using ESISA.Core.Application.Dtos.Advert.IndividualAdverts;
using ESISA.Core.Application.Dtos.Advert.WholesaleAdvert;
using ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.Create;
using ESISA.Core.Application.Features.MediatR.Commands.WholesaleAdverts.Create;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Mappings.Automapper
{
    public class WholesaleAdvertProfile : Profile
    {
        public WholesaleAdvertProfile()
        {
            this.CreateMap<CreateWholesaleAdvertCommandRequest, Advert>()
                .ForMember(e => e.Title, e => e.MapFrom(e => e.AdvertTitle))
                .ForMember(e => e.Description, e => e.MapFrom(e => e.AdvertDescription));

            this.CreateMap<CreateWholesaleAdvertCommandRequest, WholesaleAdvert>()
                .ForMember(e => e.CorporateDealerId, e => e.MapFrom(e => e.WholesaleAdvertCorporateDealerId))
                .ForMember(e => e.ProductId, e => e.MapFrom(e => e.WholesaleAdvertProductId))
                     .ForMember(e => e.MinimumPurchaseAmount, e => e.MapFrom(e => e.WholesaleAdvertMinimumPurchaseAmount))
                 .ForMember(e => e.MaximumPurchaseAmount, e => e.MapFrom(e => e.WholesaleAdvertMaximumPurchaseAmount))
                             .ForMember(e => e.PricePerUnit, e => e.MapFrom(e => e.WholesaleAdvertPricePerUnit))
                .ForMember(e => e.StockAmount, e => e.MapFrom(e => e.WholesaleAdvertStockAmount));

            this.CreateMap<CreateWholesaleAdvertCommandRequest, WholesaleAdvertDto>()
                .ForMember(e => e.AdvertTitle, e => e.MapFrom(e => e.AdvertTitle))
                .ForMember(e => e.AdvertDescription, e => e.MapFrom(e => e.AdvertDescription))
                .ForMember(e => e.WholesaleAdvertCorporateDealerId, e => e.MapFrom(e => e.WholesaleAdvertCorporateDealerId))
                .ForMember(e => e.WholesaleAdvertProductId, e => e.MapFrom(e => e.WholesaleAdvertProductId))
                .ForMember(e => e.WholesaleAdvertStockAmount, e => e.MapFrom(e => e.WholesaleAdvertStockAmount))
                 .ForMember(e => e.WholesaleAdvertMinimumPurchaseAmount, e => e.MapFrom(e => e.WholesaleAdvertMinimumPurchaseAmount))
                  .ForMember(e => e.WholesaleAdvertMaximumPurchaseAmount, e => e.MapFrom(e => e.WholesaleAdvertMaximumPurchaseAmount));

            this.CreateMap<WholesaleAdvert, WholesaleAdvertDto>()
          .ForMember(e => e.AdvertId, e => e.MapFrom(e => e.AdvertId))
          .ForMember(e => e.AdvertTitle, e => e.MapFrom(e => e.Advert.Title))
          .ForMember(e => e.AdvertDescription, e => e.MapFrom(e => e.Advert.Description))
           .ForMember(e => e.IsWholesaleAdvertActive, e => e.MapFrom(e => e.IsActive))
             .ForMember(e => e.WholesaleAdvertCorporateDealerId, e => e.MapFrom(e => e.CorporateDealerId))
          .ForMember(e => e.WholesaleAdvertProductId, e => e.MapFrom(e => e.ProductId))
          .ForMember(e => e.WholesaleAdvertPurchaseQuantityDiscountId, e => e.MapFrom(e => e.PurchaseQuantityDiscountId))
          .ForMember(e => e.WholesaleAdvertPricePerUnit, e => e.MapFrom(e => e.PricePerUnit))
           .ForMember(e => e.WholesaleAdvertDiscountedPricePerUnit, e => e.MapFrom(e => e.DiscountedPricePerUnit))
          .ForMember(e => e.WholesaleAdvertMaximumPurchaseAmount, e => e.MapFrom(e => e.MaximumPurchaseAmount))
          .ForMember(e => e.WholesaleAdvertMinimumPurchaseAmount, e => e.MapFrom(e => e.MinimumPurchaseAmount));


            this.CreateMap<WholesaleAdvert, WholesaleAdvertDetailsDto>()
             .ForMember(e => e.AdvertId, e => e.MapFrom(e => e.AdvertId))
          .ForMember(e => e.AdvertTitle, e => e.MapFrom(e => e.Advert.Title))
          .ForMember(e => e.AdvertDescription, e => e.MapFrom(e => e.Advert.Description))
           .ForMember(e => e.IsWholesaleAdvertActive, e => e.MapFrom(e => e.IsActive))
             .ForMember(e => e.WholesaleAdvertCorporateDealerId, e => e.MapFrom(e => e.CorporateDealerId))
             .ForMember(e => e.WholesaleAdvertCorporateDealerCompanyName, e => e.MapFrom(e => e.CorporateDealer.CompanyName))
          .ForMember(e => e.WholesaleAdvertProductId, e => e.MapFrom(e => e.ProductId))
            .ForMember(e => e.WholesaleAdvertProductName, e => e.MapFrom(e => e.Product.Name))
            .ForMember(e => e.WholesaleAdvertProductCategoryId, e => e.MapFrom(e => e.Product.CategoryId))
            .ForMember(e => e.WholesaleAdvertProductCategoryName, e => e.MapFrom(e => e.Product.Category.Name))
              .ForMember(e => e.WholesaleAdvertProductBrandId, e => e.MapFrom(e => e.Product.BrandId))
            .ForMember(e => e.WholesaleAdvertProductBrandName, e => e.MapFrom(e => e.Product.Brand.Name))
          .ForMember(e => e.WholesaleAdvertPurchaseQuantityDiscountId, e => e.MapFrom(e => e.PurchaseQuantityDiscountId))
          .ForMember(e => e.WholesaleAdvertPurchaseQuantityDiscountName, e => e.MapFrom(e => e.PurchaseQuantityDiscount.Description))
          .ForMember(e => e.WholesaleAdvertPurchaseQuantityDiscountRate, e => e.MapFrom(e => e.PurchaseQuantityDiscount.Rate))
          .ForMember(e => e.WholesaleAdvertPurchaseQuantityDiscountDeadline, e => e.MapFrom(e => e.PurchaseQuantityDiscount.Deadline))
          .ForMember(e => e.WholesaleAdvertPricePerUnit, e => e.MapFrom(e => e.PricePerUnit))
           .ForMember(e => e.WholesaleAdvertDiscountedPricePerUnit, e => e.MapFrom(e => e.DiscountedPricePerUnit))
          .ForMember(e => e.WholesaleAdvertMaximumPurchaseAmount, e => e.MapFrom(e => e.MaximumPurchaseAmount))
          .ForMember(e => e.WholesaleAdvertMinimumPurchaseAmount, e => e.MapFrom(e => e.MinimumPurchaseAmount));
        }
    }
}
