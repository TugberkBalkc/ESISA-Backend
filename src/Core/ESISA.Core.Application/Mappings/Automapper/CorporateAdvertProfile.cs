using AutoMapper;
using ESISA.Core.Application.Dtos.Advert.CorporateAdvert;
using ESISA.Core.Application.Dtos.Advert.CorporateAdverts;
using ESISA.Core.Application.Dtos.Advert.IndividualAdvert;
using ESISA.Core.Application.Dtos.Advert.IndividualAdverts;
using ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.Create;
using ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.Update;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.Create;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.Update;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Mappings.Automapper
{
    public class CorporateAdvertProfile : Profile
    {
        public CorporateAdvertProfile()
        {
            this.CreateMap<CreateCorporateAdvertCommandRequest, Advert>()
                .ForMember(e => e.Title, e => e.MapFrom(e => e.AdvertTitle))
                .ForMember(e => e.Description, e => e.MapFrom(e => e.AdvertDescription));

            this.CreateMap<CreateCorporateAdvertCommandRequest, CorporateAdvert>()
                .ForMember(e => e.CorporateDealerId, e => e.MapFrom(e => e.CorporateAdvertCorporateDealerId))
                .ForMember(e => e.ProductId, e => e.MapFrom(e => e.CorporateAdvertProductId))
                .ForMember(e => e.UnitPrice, e => e.MapFrom(e => e.CorporateAdvertUnitPrice))
                .ForMember(e => e.StockAmount, e => e.MapFrom(e => e.CorporateAdvertStockAmount));

            this.CreateMap<CreateCorporateAdvertCommandRequest, CorporateAdvertDto>()
                .ForMember(e => e.AdvertTitle, e => e.MapFrom(e => e.AdvertTitle))
                .ForMember(e => e.AdvertDescription, e => e.MapFrom(e => e.AdvertDescription))
                .ForMember(e => e.CorporateAdvertCorporateDealerId, e => e.MapFrom(e => e.CorporateAdvertCorporateDealerId))
                .ForMember(e => e.CorporateAdvertProductId, e => e.MapFrom(e => e.CorporateAdvertProductId))
                .ForMember(e => e.CorporateAdvertStockAmount, e => e.MapFrom(e => e.CorporateAdvertStockAmount))
                .ForMember(e => e.CorporateAdvertUnitPrice, e => e.MapFrom(e => e.CorporateAdvertUnitPrice));

            this.CreateMap<UpdateCorporateAdvertCommandRequest, Advert>()
                .ForMember(e => e.Title, e => e.MapFrom(e => e.AdvertTitle))
                .ForMember(e => e.Description, e => e.MapFrom(e => e.AdvertDescription));

            this.CreateMap<UpdateCorporateAdvertCommandRequest, CorporateAdvert>()
                .ForMember(e => e.UnitPrice, e => e.MapFrom(e => e.CorporateAdvertUnitPrice))
                .ForMember(e => e.StockAmount, e => e.MapFrom(e => e.CorporateAdvertStockAmount));

            this.CreateMap<UpdateCorporateAdvertCommandRequest, CorporateAdvertDto>()
               .ForMember(e => e.CorporateAdvertUnitPrice, e => e.MapFrom(e => e.CorporateAdvertUnitPrice))
                .ForMember(e => e.CorporateAdvertStockAmount, e => e.MapFrom(e => e.CorporateAdvertStockAmount));

            this.CreateMap<CorporateAdvert, CorporateAdvertDto>()
                 .ForMember(e => e.AdvertId, e => e.MapFrom(e => e.AdvertId))
                 .ForMember(e => e.AdvertTitle, e => e.MapFrom(e => e.Advert.Title))
                 .ForMember(e => e.AdvertDescription, e => e.MapFrom(e => e.Advert.Description))
                 .ForMember(e => e.CorporateAdvertId, e => e.MapFrom(e => e.Id))
                 .ForMember(e => e.IsCorporateAdvertActive, e => e.MapFrom(e => e.IsActive))
                 .ForMember(e => e.CorporateAdvertUnitPrice, e => e.MapFrom(e => e.UnitPrice))
                 .ForMember(e => e.CorporateAdvertStockAmount, e => e.MapFrom(e => e.StockAmount))
                 .ForMember(e => e.CorporateAdvertCorporateDealerId, e => e.MapFrom(e => e.CorporateDealerId))
                 .ForMember(e => e.CorporateAdvertProductId, e => e.MapFrom(e => e.ProductId))
                 .ForMember(e => e.CorporateAdvertPurchaseQuantityDiscountId, e => e.MapFrom(e => e.PurchaseQuantityDiscountId));

            this.CreateMap<CorporateAdvert, CorporateAdvertDetailsDto>()
                .ForMember(e => e.AdvertId, e => e.MapFrom(e => e.AdvertId))
                .ForMember(e => e.AdvertTitle, e => e.MapFrom(e => e.Advert.Title))
                .ForMember(e => e.AdvertDescription, e => e.MapFrom(e => e.Advert.Description))
                .ForMember(e => e.CorporateAdvertId, e => e.MapFrom(e => e.Id))
                .ForMember(e => e.IsCorporateAdvertActive, e => e.MapFrom(e => e.IsActive))
                .ForMember(e => e.CorporateAdvertUnitPrice, e => e.MapFrom(e => e.UnitPrice))
                .ForMember(e => e.CorporateAdvertStockAmount, e => e.MapFrom(e => e.StockAmount))
                .ForMember(e => e.CorporateAdvertProductId, e => e.MapFrom(e => e.ProductId))
                .ForMember(e => e.CorporateAdvertProductName, e => e.MapFrom(e => e.Product.Name))
                .ForMember(e => e.CorporateAdvertProductCategoryId, e => e.MapFrom(e => e.Product.CategoryId))
                .ForMember(e => e.CorporateAdvertProductCategoryName, e => e.MapFrom(e => e.Product.Category.Name))
                .ForMember(e => e.CorporateAdvertCorporateDealerId, e => e.MapFrom(e => e.CorporateDealerId))
                .ForMember(e => e.CorporateAdvertCorporateDealerCompanyName, e => e.MapFrom(e => e.CorporateDealer.CompanyName))
                .ForMember(e => e.CorporateAdvertProductBrandId, e => e.MapFrom(e => e.Product.BrandId))
                .ForMember(e => e.CorporateAdvertProductBrandName, e => e.MapFrom(e => e.Product.Brand.Name))
                .ForMember(e => e.CorporateAdvertPurchaseQuantityDiscountId, e => e.MapFrom(e => e.PurchaseQuantityDiscountId))
                .ForMember(e => e.CorporateAdvertPurchaseQuantityDiscountName, e => e.MapFrom(e => e.PurchaseQuantityDiscount.Description))
                .ForMember(e => e.CorporateAdvertPurchaseQuantityDiscountDeadline, e => e.MapFrom(e => e.PurchaseQuantityDiscount.Deadline))
                .ForMember(e => e.CorporateAdvertFavoritesCount, e => e.MapFrom(e => e.IndividualCustomerCorporateAdvertFavorites.Count))
                .ForMember(e => e.CorporateAdvertFavoritesCount, e => e.MapFrom(e => e.IndividualCustomerCorporateAdvertComments.Count));
        }
    }
}
