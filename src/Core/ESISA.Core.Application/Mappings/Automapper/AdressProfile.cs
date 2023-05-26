using AutoMapper;
using ESISA.Core.Application.Dtos.Adresses;
using ESISA.Core.Application.Dtos.Advert;
using ESISA.Core.Application.Features.MediatR.Commands.Addresses.Create;
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
            this.CreateMap<CreateAddressCommandRequest, Address>()
              .ForMember(e => e.CountryId, e => e.MapFrom(e => e.AddressCountryId))
              .ForMember(e => e.CityId, e => e.MapFrom(e => e.AddressCityId))
              .ForMember(e => e.Details, e => e.MapFrom(e => e.AddressDetails))
              .ForMember(e => e.DistrictId, e => e.MapFrom(e => e.AddressDistrictId))
              .ForMember(e => e.PostalCode, e => e.MapFrom(e => e.AddressPostalCode))
              .ReverseMap();

            this.CreateMap<Address, AddressDetailsDto>()
                .ForMember(e => e.CountryId, e => e.MapFrom(e => e.CountryId))
                .ForMember(e => e.CountryName, e => e.MapFrom(e => e.Country.Name))
                .ForMember(e => e.CityId, e => e.MapFrom(e => e.CityId))
                .ForMember(e => e.CountryName, e => e.MapFrom(e => e.City.Name))
                .ForMember(e => e.DistrictId, e => e.MapFrom(e => e.DistrictId))
                .ForMember(e => e.DistrictName, e => e.MapFrom(e => e.District.Name))
                .ForMember(e => e.Details, e => e.MapFrom(e => e.Details))
                .ForMember(e => e.PostalCode, e => e.MapFrom(e => e.PostalCode))
                .ReverseMap();

            this.CreateMap<Address, AddressDto>();
        }
    }
}
