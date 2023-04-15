using AutoMapper;
using ESISA.Core.Application.Dtos.Advert.CorporateAdverts;
using ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.Create;
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
                .ForMember(e => e.StockAmount, e => e.MapFrom(e => e.CorporateAdvertStockAmount))
                .ForMember(e => e.UnitPrice, e => e.MapFrom(e => e.CorporateAdvertUnitPrice));

            this.CreateMap<CreateCorporateAdvertCommandRequest, NotDiscountedCorporateAdvertDto>()
                .ForMember(e => e.AdvertTitle, e => e.MapFrom(e => e.AdvertTitle))
                .ForMember(e => e.AdvertDescription, e => e.MapFrom(e => e.AdvertDescription))
                .ForMember(e => e.CorporateAdvertCorporateDealerId, e => e.MapFrom(e => e.CorporateAdvertCorporateDealerId))
                .ForMember(e => e.CorporateAdvertProductId, e => e.MapFrom(e => e.CorporateAdvertProductId))
                .ForMember(e => e.CorporateAdvertStockAmount, e => e.MapFrom(e => e.CorporateAdvertStockAmount))
                .ForMember(e => e.CorporateAdvertUnitPrice, e => e.MapFrom(e => e.CorporateAdvertUnitPrice));


            this.CreateMap<CreateCorporateAdvertCommandRequest, DiscountedCorporateAdvertDto>()
                .ForMember(e => e.AdvertTitle, e => e.MapFrom(e => e.AdvertTitle))
                .ForMember(e => e.AdvertDescription, e => e.MapFrom(e => e.AdvertDescription))
                .ForMember(e => e.CorporateAdvertCorporateDealerId, e => e.MapFrom(e => e.CorporateAdvertCorporateDealerId))
                .ForMember(e => e.CorporateAdvertProductId, e => e.MapFrom(e => e.CorporateAdvertProductId))
                .ForMember(e => e.CorporateAdvertStockAmount, e => e.MapFrom(e => e.CorporateAdvertStockAmount))
                .ForMember(e => e.CorporateAdvertUnitPrice, e => e.MapFrom(e => e.CorporateAdvertUnitPrice));
                
        }

        //   this.CreateMap<UpdateIndividualAdvertCommandRequest, Advert>()
        //       .ForMember(e => e.Title, e => e.MapFrom(e => e.AdvertTitle))
        //       .ForMember(e => e.Description, e => e.MapFrom(e => e.AdvertDescription));

        //   this.CreateMap<UpdateIndividualAdvertCommandRequest, IndividualAdvert>()
        //   .ForMember(e => e.Price, e => e.MapFrom(e => e.IndividualAdvertPrice))
        //   .ForMember(e => e.Bargain, e => e.MapFrom(e => e.IndividualAdvertBargain))
        //   .ForMember(e => e.ProductConditionType, e => e.MapFrom(e => e.IndividualAdvertProductConditionType));
    }
}
