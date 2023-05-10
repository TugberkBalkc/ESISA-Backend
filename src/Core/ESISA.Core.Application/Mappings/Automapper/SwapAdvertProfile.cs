using AutoMapper;
using ESISA.Core.Application.Dtos.Advert.SwapAdvert;
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
        }
    }
}
