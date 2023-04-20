using AutoMapper;
using ESISA.Core.Application.Dtos.Advert.Common;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Mappings.Automapper
{
    public class AdvertPhotoPathProfile : Profile
    {
        public AdvertPhotoPathProfile()
        {
            this.CreateMap<AdvertPhotoPath, AdvertPhotoPathDto>()
                .ForMember(e => e.AdvertPhotoPathId, e => e.MapFrom(e => e.Id))
                .ForMember(e => e.AdvertPhotoPathCreatedDate, e => e.MapFrom(e => e.CreatedDate))
                .ForMember(e => e.AdvertPhotoPathModifiedDate, e => e.MapFrom(e => e.ModifiedDate))
                .ForMember(e => e.AdvertPhotoPathIsActive, e => e.MapFrom(e => e.IsActive))
                .ForMember(e => e.AdvertPhotoPathIsDeleted, e => e.MapFrom(e => e.IsDeleted))
                .ForMember(e => e.AdvertId, e => e.MapFrom(e => e.AdvertId))
                .ForMember(e => e.AdvertPhotoUrl, e => e.MapFrom(e => e.PhotoPath));
        }
    }   
}
