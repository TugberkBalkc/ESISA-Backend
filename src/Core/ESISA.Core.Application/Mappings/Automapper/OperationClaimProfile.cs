using AutoMapper;
using ESISA.Core.Application.Dtos.Security.Authorization;
using ESISA.Core.Application.Features.MediatR.Commands.OperationClaims.Create;
using ESISA.Core.Application.Features.MediatR.Commands.OperationClaims.Update;
using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Mappings.Automapper
{
    public class OperationClaimProfile : Profile
    {
        public OperationClaimProfile()
        {
            this.CreateMap<CreateOperationClaimCommandRequest, OperationClaim>()
                .ForMember(e => e.ClaimName, e => e.MapFrom(e => e.OperationClaimName));

            this.CreateMap<UpdateOperationClaimCommandRequest, OperationClaim>()
                .ForMember(e => e.Id, e => e.MapFrom(e => e.OperationClaimId))
                .ForMember(e => e.IsActive, e => e.MapFrom(e => e.OperationClaimIsActive))
                .ForMember(e => e.ClaimName, e => e.MapFrom(e => e.OperationClaimName));

            this.CreateMap<OperationClaim, OperationClaimDto>()
                .ForMember(e => e.OperationClaimId, e => e.MapFrom(e => e.Id))
                .ForMember(e => e.OperationClaimCreatedDate, e => e.MapFrom(e => e.CreatedDate))
                .ForMember(e => e.OperationClaimModifiedDate, e => e.MapFrom(e => e.ModifiedDate))
                .ForMember(e => e.OperationClaimIsActive, e => e.MapFrom(e => e.IsActive))
                .ForMember(e => e.OperationClaimIsDeleted, e => e.MapFrom(e => e.IsDeleted))
                .ForMember(e => e.OperationClaimName, e => e.MapFrom(e => e.ClaimName));
        }
    }
}
