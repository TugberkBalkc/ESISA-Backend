using AutoMapper;
using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Dtos.Security.Authorization;
using ESISA.Core.Application.Features.MediatR.Commands.Roles.AddOperationClaim;
using ESISA.Core.Application.Features.MediatR.Commands.Roles.Create;
using ESISA.Core.Application.Features.MediatR.Commands.Roles.Update;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Mappings.Automapper
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            this.CreateMap<CreateRoleCommandRequest, Role>()
                .ForMember(e => e.Name, e => e.MapFrom(e => e.RoleName));

            this.CreateMap<UpdateRoleCommandRequest, Role>()
             .ForMember(e => e.Id, e => e.MapFrom(e => e.RoleId))
             .ForMember(e => e.IsActive, e => e.MapFrom(e => e.RoleIsActive))
             .ForMember(e => e.Name, e => e.MapFrom(e => e.RoleName));

            this.CreateMap<AddOperationClaimToRoleCommandRequest, RoleOperationClaim>()
                .ForMember(e => e.RoleId, e => e.MapFrom(e => e.RoleId))
                .ForMember(e => e.OperationClaimId, e => e.MapFrom(e => e.OperationClaimId));

            this.CreateMap<Role, RoleDto>()
                .ForMember(e => e.RoleId, e => e.MapFrom(e => e.Id))
                .ForMember(e => e.RoleCreatedDate, e => e.MapFrom(e => e.CreatedDate))
                .ForMember(e => e.RoleModifiedDate, e => e.MapFrom(e => e.ModifiedDate))
                .ForMember(e => e.RoleIsActive, e => e.MapFrom(e => e.IsActive))
                .ForMember(e => e.RoleIsDeleted, e => e.MapFrom(e => e.IsDeleted))
                .ForMember(e => e.RoleName, e => e.MapFrom(e => e.Name));

            this.CreateMap<RoleOperationClaim, RoleOperationClaimDto>()
                .ForMember(e => e.RoleOperationClaimId, e => e.MapFrom(e => e.Id))
                .ForMember(e => e.RoleOperationClaimCreatedDate, e => e.MapFrom(e => e.CreatedDate))
                .ForMember(e => e.RoleOperationClaimModifiedDate, e => e.MapFrom(e => e.ModifiedDate))
                .ForMember(e => e.RoleOperationClaimIsActive, e => e.MapFrom(e => e.IsActive))
                .ForMember(e => e.RoleOperationClaimIsDeleted, e => e.MapFrom(e => e.IsDeleted))
                .ForMember(e => e.RoleId, e => e.MapFrom(e => e.RoleId))
                .ForMember(e => e.OperationClaimId, e => e.MapFrom(e => e.OperationClaim));

        }
    }
}
