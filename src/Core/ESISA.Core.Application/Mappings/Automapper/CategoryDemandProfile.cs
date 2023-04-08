using AutoMapper;
using ESISA.Core.Application.Dtos.Demand;
using ESISA.Core.Application.Features.MediatR.Commands.Demands.CreateCategoryDemand;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Mappings.Automapper
{
    public class CategoryDemandProfile : Profile
    {
        public CategoryDemandProfile()
        {
            CreateMap<CreateCategoryDemandCommandRequest, CategoryDemand>()
               .ForMember(e => e.CorporateDealerId, e => e.MapFrom(e => e.CorporateDealerId))
               .ForMember(e => e.SenderNote, e => e.MapFrom(e => e.SenderNote))
               .ForMember(e => e.CategoryName, e => e.MapFrom(e => e.CategoryName));

            CreateMap<CategoryDemand, CategoryDemandDto>()
                .ForMember(e => e.CategoryDemandId, e => e.MapFrom(e => e.Id))
                .ForMember(e => e.CategoryDemandCreatedDate, e => e.MapFrom(e => e.CreatedDate))
                .ForMember(e => e.CategoryDemandModifiedDate, e => e.MapFrom(e => e.ModifiedDate))
                .ForMember(e => e.CategoryDemandIsActive, e => e.MapFrom(e => e.IsActive))
                .ForMember(e => e.CategoryDemandIsDeleted, e => e.MapFrom(e => e.IsDeleted))
                .ForMember(e => e.CorporateDealerId, e => e.MapFrom(e => e.CorporateDealerId))
                .ForMember(e => e.SenderNote, e => e.MapFrom(e => e.SenderNote))
                .ForMember(e => e.CategoryName, e => e.MapFrom(e => e.CategoryName));
        }
    }
}
