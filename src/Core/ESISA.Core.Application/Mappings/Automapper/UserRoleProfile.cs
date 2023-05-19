using AutoMapper;
using ESISA.Core.Application.Dtos.Security.Authorization;
using ESISA.Core.Application.Features.MediatR.Commands.UserRoles.Create;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Mappings.Automapper
{
    public class UserRoleProfile : Profile
    {
        public UserRoleProfile()
        {
            this.CreateMap<CreateUserRoleCommandRequest, UserRole>();

            this.CreateMap<UserRole, UserRoleDto>()
                .ForMember(e => e.UserRoleId, e => e.MapFrom(e => e.Id))
                .ForMember(e => e.UserRoleCreatedDate, e => e.MapFrom(e => e.CreatedDate))
                .ForMember(e => e.UserRoleModifiedDate, e => e.MapFrom(e => e.ModifiedDate))
                .ForMember(e => e.UserRoleIsActive, e => e.MapFrom(e => e.IsActive))
                .ForMember(e => e.UserRoleIsDeleted, e => e.MapFrom(e => e.IsDeleted));
        }
    }
}
