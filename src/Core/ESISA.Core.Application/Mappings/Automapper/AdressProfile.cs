using AutoMapper;
using ESISA.Core.Application.Dtos.Adress;
using ESISA.Core.Application.Dtos.Advert;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Mappings.Automapper
{
    public class AdressProfile : Profile
    {
        public AdressProfile()
        {
            this.CreateMap<Address, AdressDto>()
                .ForMember(e => e.Id, e => e.MapFrom(e => e.Id))
                .ForMember(e => e.CountryId, e => e.MapFrom(e => e.CountryId))
                .ForMember(e => e.CityId,e=>e.MapFrom(e=>e.CityId))
                .ForMember(e => e.Details, e => e.MapFrom(e => e.Details))
                .ForMember(e => e.DistrictId, e => e.MapFrom(e => e.DistrictId))
                .ForMember(e => e.PostalCode, e => e.MapFrom(e => e.PostalCode))
                .ReverseMap();
        }
    }
}
