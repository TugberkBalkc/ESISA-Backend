using AutoMapper;
using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Features.MediatR.Commands.Demands.CreateBrandDemand;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Mappings.Automapper
{
    public class BrandDemandProfile : Profile
    {
        public BrandDemandProfile()
        {
            CreateMap<CreateBrandDemandCommandRequest, BrandDemand>()
                .ForMember(e => e.CorporateDealerId, e => e.MapFrom(e => e.CorporateDealerId))
                .ForMember(e => e.SenderNote, e => e.MapFrom(e => e.SenderNote))
                .ForMember(e => e.BrandName, e => e.MapFrom(e => e.BrandName));

            CreateMap<BrandDemand, BrandDemandDto>()
                .ForMember(e => e.BrandDemandId, e => e.MapFrom(e => e.Id))
                .ForMember(e => e.BrandDemandCreatedDate, e => e.MapFrom(e => e.CreatedDate))
                .ForMember(e => e.BrandDemandModifiedDate, e => e.MapFrom(e => e.ModifiedDate))
                .ForMember(e => e.BrandDemandIsActive, e => e.MapFrom(e => e.IsActive))
                .ForMember(e => e.BrandDemandIsDeleted, e => e.MapFrom(e => e.IsDeleted))
                .ForMember(e => e.CorporateDealerId, e => e.MapFrom(e => e.CorporateDealerId))
                .ForMember(e => e.SenderNote, e => e.MapFrom(e => e.SenderNote))
                .ForMember(e => e.BrandName, e => e.MapFrom(e => e.BrandName));
        }
    }
}
