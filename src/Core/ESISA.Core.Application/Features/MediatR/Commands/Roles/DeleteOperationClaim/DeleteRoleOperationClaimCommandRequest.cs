using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Roles.DeleteOperationClaim
{
    public class DeleteRoleOperationClaimCommandRequest : IRequest<DeleteRoleOperationClaimCommandResponse>
    {
        public Guid RoleOperationClaimId { get; set; }

        public DeleteRoleOperationClaimCommandRequest()
        {

        }

        public DeleteRoleOperationClaimCommandRequest(Guid roleOperationClaimId)
        {
            RoleOperationClaimId = roleOperationClaimId;
        }
    }
}
