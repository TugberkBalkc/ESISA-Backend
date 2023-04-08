using AutoMapper;
using ESISA.Core.Application.Dtos.CorporateCustomer;
using ESISA.Core.Application.Dtos.Security.Authentication.Registrations;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Mappings.Automapper
{
    public class CorporateCustomerProfile : Profile
    {
        public CorporateCustomerProfile()
        {
            this.CreateMap<RegisterCorporateCustomerDto, CorporateCustomerDto>();

            this.CreateMap<RegisterCorporateCustomerDto, User>()
                .ForMember(e => e.UserName, e => e.MapFrom(e => e.CorporateCustomerUserName))
                .ForMember(e => e.Email, e => e.MapFrom(e => e.CorporateCustomerEmail))
                .ForMember(e => e.ContactNumber, e => e.MapFrom(e => e.CorporateCustomerContactNumber));

            this.CreateMap<RegisterCorporateCustomerDto, CorporateCustomer>()
                .ForMember(e => e.CompanyName, e => e.MapFrom(e => e.CorporateCustomerCompanyName))
                .ForMember(e => e.TaxIdentityNumber, e => e.MapFrom(e => e.CorporateCustomerTaxIdentityNumber))
                .ForMember(e => e.CompanyName, e => e.MapFrom(e => e.CorporateCustomerCompanyName));
        }
    }
}
