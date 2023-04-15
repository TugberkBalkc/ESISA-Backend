using AutoMapper;
using ESISA.Core.Application.Dtos.Advert;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.CreateIndividualAdvert;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Mappings.Automapper
{
    public class IndividualAdvertProfile : Profile
    {
        public IndividualAdvertProfile()
        {
            this.CreateMap<CreateIndividualAdvertCommandRequest, Advert>()
                .ForMember(e => e.Title, e => e.MapFrom(e => e.AdvertTitle))
                .ForMember(e => e.Description, e => e.MapFrom(e => e.AdvertDescription));

            this.CreateMap<CreateIndividualAdvertCommandRequest, IndividualAdvert>()
                .ForMember(e => e.IndividualDealerId, e => e.MapFrom(e => e.IndividualAdvertIndividualDealerId))
                .ForMember(e => e.ProductId, e => e.MapFrom(e => e.IndividualAdvertProductId))
                .ForMember(e => e.Price, e => e.MapFrom(e => e.IndividualAdvertPrice))
                .ForMember(e => e.Bargain, e => e.MapFrom(e => e.IndividualAdvertBargain))
                .ForMember(e => e.ProductConditionType, e => e.MapFrom(e => e.IndividualAdvertProductConditionType));

            this.CreateMap<CreateIndividualAdvertCommandRequest, IndividualAdvertDto>()
                .ForMember(e => e.AdvertTitle, e => e.MapFrom(e => e.AdvertTitle))
                .ForMember(e => e.AdvertDescription, e => e.MapFrom(e => e.AdvertDescription))
                .ForMember(e => e.IndividualAdvertIndividualDealerId, e => e.MapFrom(e => e.IndividualAdvertIndividualDealerId))
                .ForMember(e => e.IndividualAdvertProductId, e => e.MapFrom(e => e.IndividualAdvertProductId))
                .ForMember(e => e.IndividualAdvertProductConditionType, e => e.MapFrom(e => e.IndividualAdvertProductConditionType));
               
        }
    }
}
