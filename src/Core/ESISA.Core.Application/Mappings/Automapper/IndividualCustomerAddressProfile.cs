using AutoMapper;
using ESISA.Core.Application.Dtos.Adress;
using ESISA.Core.Application.Dtos.Product;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Mappings.Automapper
{
    public class IndividualCustomerAddressProfile : Profile
    {
        public IndividualCustomerAddressProfile()
        {
            this.CreateMap<IndividualCustomerAddress, IndividualCustomerAddressDto>()
                .ForMember(e => e.Id, e => e.MapFrom(e => e.Id))
               .ForMember(e => e.AddressId, e => e.MapFrom(e => e.AddressId))
               .ForMember(e => e.IndividualCustomerId, e => e.MapFrom(e => e.IndividualCustomerId))
               .ForMember(e => e.IsResidence, e => e.MapFrom(e => e.IsResidence));

            this.CreateMap<IndividualCustomerAddress, IndividualCustomerAddressDetailsDto>()
             .ForMember(e => e.Id, e => e.MapFrom(e => e.Id))
             .ForMember(e => e.AddressId, e => e.MapFrom(e => e.AddressId))      
             .ForMember(e => e.IndividualCustomerId, e => e.MapFrom(e => e.IndividualCustomerId))
             .ForMember(e => e.IndividualCustomerFirstName, e => e.MapFrom(e => e.IndividualCustomer.FirstName))
             .ForMember(e => e.IndividualCustomerLastName, e => e.MapFrom(e => e.IndividualCustomer.LastName))
             .ForMember(e => e.IsResidence, e => e.MapFrom(e => e.IsResidence))
             .ForMember(e => e.AdressDetailsDto.CityId, e => e.MapFrom(e => e.Address.CityId))
             .ForMember(e => e.AdressDetailsDto.CityName, e => e.MapFrom(e => e.Address.City.Name))
             .ForMember(e => e.AdressDetailsDto.CountryId, e => e.MapFrom(e => e.Address.CountryId))
             .ForMember(e => e.AdressDetailsDto.CountryName, e => e.MapFrom(e => e.Address.Country.Name))
             .ForMember(e => e.AdressDetailsDto.DistrictId, e => e.MapFrom(e => e.Address.DistrictId))
             .ForMember(e => e.AdressDetailsDto.DistrictName, e => e.MapFrom(e => e.Address.District.Name))
             .ForMember(e => e.AdressDetailsDto.CityName, e => e.MapFrom(e => e.Address.City.Name))
             .ForMember(e => e.AdressDetailsDto.CountryName, e => e.MapFrom(e => e.Address.Country.Name))
             .ForMember(e => e.AdressDetailsDto.Details, e => e.MapFrom(e => e.Address.Details))
             .ForMember(e => e.AdressDetailsDto.DistrictName, e => e.MapFrom(e => e.Address.District.Name));
        } 
    }
}
