using AutoMapper;
using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Features.MediatR.Commands.Products.Create;
using ESISA.Core.Application.Features.MediatR.Commands.Products.Update;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Mappings.Automapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            this.CreateMap<CreateProductCommandRequest, Product>()
             .ForMember(e => e.Name, e => e.MapFrom(e => e.ProductName))
             .ForMember(e => e.CategoryId, e => e.MapFrom(e => e.CategoryId))
             .ForMember(e => e.BrandId, e => e.MapFrom(e => e.BrandId));

            this.CreateMap<UpdateProductCommandRequest, Product>()
          .ForMember(e => e.Id, e => e.MapFrom(e => e.ProductId))
          .ForMember(e=>e.IsActive, e=>e.MapFrom(e=>e.ProductIsActive))
          .ForMember(e => e.Name, e => e.MapFrom(e => e.ProductName))
          .ForMember(e => e.CategoryId, e => e.MapFrom(e => e.CategoryId))
          .ForMember(e => e.BrandId, e => e.MapFrom(e => e.BrandId));

            this.CreateMap<Product, ProductDto>()
                .ForMember(e => e.ProductId, e => e.MapFrom(e => e.Id))
                .ForMember(e => e.ProductCreatedDate, e => e.MapFrom(e => e.CreatedDate))
                .ForMember(e => e.ProductModifiedDate, e => e.MapFrom(e => e.ModifiedDate))
                .ForMember(e => e.ProductIsActive, e => e.MapFrom(e => e.IsActive))
                .ForMember(e => e.ProductIsDeleted, e => e.MapFrom(e => e.IsDeleted))
                .ForMember(e => e.ProductName, e => e.MapFrom(e => e.Name))
                .ForMember(e => e.CategoryId, e => e.MapFrom(e => e.CategoryId))
                .ForMember(e => e.BrandId, e => e.MapFrom(e => e.BrandId));
        }
    }
}
