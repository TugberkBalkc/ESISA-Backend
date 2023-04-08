using AutoMapper;
using ESISA.Core.Application.Dtos.Category;
using ESISA.Core.Application.Features.MediatR.Commands.Categories.CreateMainCategory;
using ESISA.Core.Application.Features.MediatR.Commands.Categories.CreateSubCategory;
using ESISA.Core.Application.Features.MediatR.Commands.Categories.Update;
using ESISA.Core.Application.Features.MediatR.Commands.Categories.UpdateMainCategory;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Mappings.Automapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            this.CreateMap<CreateMainCategoryCommandRequest, Category>()
                .ForMember(e => e.Name, e => e.MapFrom(e => e.CategoryName))
                .ForMember(e => e.Description, e => e.MapFrom(e => e.CategoryDescription));

            this.CreateMap<UpdateMainCategoryCommandRequest, Category>()
              .ForMember(e => e.Id, e => e.MapFrom(e => e.CategoryId))
              .ForMember(e => e.IsActive, e => e.MapFrom(e => e.CategoryIsActive))
              .ForMember(e => e.Name, e => e.MapFrom(e => e.CategoryName))
              .ForMember(e => e.Description, e => e.MapFrom(e => e.CategoryDescription));

            this.CreateMap<CreateSubCategoryCommandRequest, Category>()
             .ForMember(e=>e.ParentId, e=>e.MapFrom(e=>e.ParentCategoryId))
             .ForMember(e => e.Name, e => e.MapFrom(e => e.CategoryName))
             .ForMember(e => e.Description, e => e.MapFrom(e => e.CategoryDescription));

            this.CreateMap<UpdateSubCategoryCommandRequest, Category>()
              .ForMember(e => e.Id, e => e.MapFrom(e => e.CategoryId))
              .ForMember(e => e.IsActive, e => e.MapFrom(e => e.CategoryIsActive))
              .ForMember(e => e.ParentId, e => e.MapFrom(e => e.ParentCategoryId))
              .ForMember(e => e.Name, e => e.MapFrom(e => e.CategoryName))
              .ForMember(e => e.Description, e => e.MapFrom(e => e.CategoryDescription));

            this.CreateMap<Category, CategoryDto>()
                .ForMember(e => e.CategoryId, e => e.MapFrom(e => e.Id))
                .ForMember(e => e.CategoryCreatedDate, e => e.MapFrom(e => e.CreatedDate))
                .ForMember(e => e.CategoryModifiedDate, e => e.MapFrom(e => e.ModifiedDate))
                .ForMember(e => e.CategoryIsActive, e => e.MapFrom(e => e.IsActive))
                .ForMember(e => e.CategoryIsDeleted, e => e.MapFrom(e => e.IsDeleted))
                .ForMember(e=>e.ParentCategoryId, e=>e.MapFrom(e=>e.ParentId))
                .ForMember(e => e.CategoryName, e => e.MapFrom(e => e.Name))
                .ForMember(e => e.CategoryDescription, e => e.MapFrom(e => e.Description));
        }
    }
}
