using AutoMapper;
using ESISA.Core.Application.Dtos.Adress;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Mappings.Automapper
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            this.CreateMap<City, CityDto>()
                .ForMember(e => e.Id, e => e.MapFrom(e => e.Id))
                .ForMember(e => e.Name, e => e.MapFrom(e => e.Name))
                .ForMember(e => e.CountryId, e => e.MapFrom(e => e.CountryId));
               

        }
    }
}
