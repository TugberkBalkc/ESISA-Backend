using AutoMapper;
using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Dtos.User;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Mappings.Automapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            this.CreateMap<User, UserDto>()
                .ForMember(e => e.UserId, e => e.MapFrom(e => e.Id))
                .ForMember(e => e.UserName, e => e.MapFrom(e => e.UserName))
                .ForMember(e => e.UserEmail, e => e.MapFrom(e => e.Email))
                .ForMember(e => e.UserContactNumber, e => e.MapFrom(e => e.ContactNumber));
        }
    }
}
