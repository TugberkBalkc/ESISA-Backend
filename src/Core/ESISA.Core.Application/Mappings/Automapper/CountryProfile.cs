using AutoMapper;
using ESISA.Core.Application.Dtos.Adresses;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Mappings.Automapper
{
    public class CountryProfile: Profile
    {
        public CountryProfile()
        {
            this.CreateMap<Country, CountryDto>()
                .ForMember(e => e.Id, e => e.MapFrom(e => e.Id))
                .ForMember(e => e.Name, e => e.MapFrom(e => e.Name));


        }
    }
}
