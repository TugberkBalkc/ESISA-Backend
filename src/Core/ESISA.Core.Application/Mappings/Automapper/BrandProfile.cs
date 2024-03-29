﻿using AutoMapper;
using ESISA.Core.Application.Dtos.Brand;
using ESISA.Core.Application.Features.MediatR.Commands.Brands.Create;
using ESISA.Core.Application.Features.MediatR.Commands.Brands.Update;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Mappings.Automapper
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            this.CreateMap<CreateBrandCommandRequest, Brand>()
                .ForMember(e => e.Name, e => e.MapFrom(e => e.BrandName))
                .ForMember(e => e.WebsiteUrl, e => e.MapFrom(e => e.BrandWebsiteUrl));

            this.CreateMap<UpdateBrandCommandRequest, Brand>()
              .ForMember(e => e.Id, e => e.MapFrom(e => e.BrandId))
              .ForMember(e=>e.IsActive, e=>e.MapFrom(e=>e.BrandIsActive))
              .ForMember(e => e.Name, e => e.MapFrom(e => e.BrandName))
              .ForMember(e => e.WebsiteUrl, e => e.MapFrom(e => e.BrandWebsiteUrl));


            this.CreateMap<Brand, BrandDto>()
              .ForMember(e => e.BrandId, e => e.MapFrom(e => e.Id))
              .ForMember(e => e.BrandCreatedDate, e => e.MapFrom(e => e.CreatedDate))
              .ForMember(e => e.BrandModifiedDate, e => e.MapFrom(e => e.ModifiedDate))
              .ForMember(e => e.BrandIsActive, e => e.MapFrom(e => e.IsActive))
              .ForMember(e => e.BrandIsDeleted, e => e.MapFrom(e => e.IsDeleted))
              .ForMember(e => e.BrandName, e => e.MapFrom(e => e.Name))
              .ForMember(e => e.BrandWebsiteUrl, e => e.MapFrom(e => e.WebsiteUrl));
        }
    }
}
