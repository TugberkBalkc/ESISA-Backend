using AutoMapper;
using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Features.MediatR.Commands.Demands.CreateProductDemand;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Mappings.Automapper
{
    public class ProductDemandProfile : Profile
    {
        public ProductDemandProfile()
        {
            CreateMap<CreateProductDemandCommandRequest, ProductDemand>()
             .ForMember(e => e.CorporateDealerId, e => e.MapFrom(e => e.CorporateDealerId))
             .ForMember(e => e.SenderNote, e => e.MapFrom(e => e.SenderNote))
             .ForMember(e => e.ProductName, e => e.MapFrom(e => e.ProductName));

            CreateMap<ProductDemand, ProductDemandDto>()
                .ForMember(e => e.ProductDemandId, e => e.MapFrom(e => e.Id))
                .ForMember(e => e.ProductDemandCreatedDate, e => e.MapFrom(e => e.CreatedDate))
                .ForMember(e => e.ProductDemandModifiedDate, e => e.MapFrom(e => e.ModifiedDate))
                .ForMember(e => e.ProductDemandIsActive, e => e.MapFrom(e => e.IsActive))
                .ForMember(e => e.ProductDemandIsDeleted, e => e.MapFrom(e => e.IsDeleted))
                .ForMember(e => e.CorporateDealerId, e => e.MapFrom(e => e.CorporateDealerId))
                .ForMember(e => e.SenderNote, e => e.MapFrom(e => e.SenderNote))
                .ForMember(e => e.CategoryId, e => e.MapFrom(e => e.CategoryId))
                .ForMember(e => e.ProductName, e => e.MapFrom(e => e.ProductName));
        }
    }
}
