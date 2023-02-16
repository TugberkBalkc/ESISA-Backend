using AutoMapper;
using ESISA.Core.Application.Dtos.Advert;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Mappings.Automapper
{
    public class AdvertProfile : Profile
    {
        public AdvertProfile()
        {
            this.CreateMap<CreateIndividualAdvertDto, Advert>()
                .ForMember(e => e.Title, e => e.MapFrom(e => e.AdvertTitle))
                .ForMember(e => e.Description, e => e.MapFrom(e => e.AdvertDescription))
                .ReverseMap();

            this.CreateMap<CreateIndividualAdvertDto, IndividualAdvert>()
                .ForMember(e => e.AdvertId, e => e.MapFrom(e => e))
                .ForMember(e => e.Description, e => e.MapFrom(e => e.AdvertDescription))
                .ReverseMap();
        }
    }
}
