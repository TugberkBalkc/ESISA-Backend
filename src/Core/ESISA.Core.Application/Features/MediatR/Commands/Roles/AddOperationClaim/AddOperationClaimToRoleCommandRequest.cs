using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.Roles.AddOperationClaim
{
    public class AddOperationClaimToRoleCommandRequest : IRequest<AddOperationClaimToRoleCommandResponse>
    {
        public Guid RoleId { get; set; }
        public Guid OperationClaimId { get; set; }

        public AddOperationClaimToRoleCommandRequest()
        {

        }

        public AddOperationClaimToRoleCommandRequest(Guid roleId, Guid operationClaimId)
        {
            RoleId = roleId;
            OperationClaimId = operationClaimId;
        }
    }
}
