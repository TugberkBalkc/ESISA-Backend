using AutoMapper;
using ESISA.Core.Application.Dtos.Security.Authentication.Registrations;
using ESISA.Core.Application.Dtos.User;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Mappings.Automapper
{
    public class CorporateDealerProfile : Profile
    {
        public CorporateDealerProfile()
        {
            this.CreateMap<RegisterCorporateDealerDto, CorporateDealerDto>();

            this.CreateMap<RegisterCorporateDealerDto, User>()
                .ForMember(e => e.UserName, e => e.MapFrom(e => e.CorporateDealerUserName))
                .ForMember(e => e.Email, e => e.MapFrom(e => e.CorporateDealerEmail))
                .ForMember(e => e.ContactNumber, e => e.MapFrom(e => e.CorporateDealerContactNumber));

            this.CreateMap<RegisterCorporateDealerDto, CorporateDealer>()
                .ForMember(e => e.SalesCategoryId, e => e.MapFrom(e => e.CorporateDealerSalesCategoryId))
                .ForMember(e => e.CompanyName, e => e.MapFrom(e => e.CorporateDealerCompanyName))
                .ForMember(e => e.TaxIdentityNumber, e => e.MapFrom(e => e.CorporateDealerTaxIdentityNumber))
                .ForMember(e => e.CompanyType, e => e.MapFrom(e => e.CorporateDealerCompanyType));
        }
    }
}
