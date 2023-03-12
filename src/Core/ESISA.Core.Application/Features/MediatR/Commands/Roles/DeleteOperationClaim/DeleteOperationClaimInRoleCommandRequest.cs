using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Roles.DeleteOperationClaim
{
    public class DeleteOperationClaimInRoleCommandRequest : IRequest<DeleteOperationClaimInRoleCommandResponse>
    {
        public Guid RoleOperationClaimId { get; set; }

        public DeleteOperationClaimInRoleCommandRequest()
        {

        }

        public DeleteOperationClaimInRoleCommandRequest(Guid roleOperationClaimId)
        {
            RoleOperationClaimId = roleOperationClaimId;
        }
    }
}
