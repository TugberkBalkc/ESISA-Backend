using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.OperationClaims.DeleteRange
{
    public class DeleteRangeOperationClaimCommandRequest : IRequest<DeleteRangeOperationClaimCommandResponse>
    {
        public Guid[] OperationClaimIds { get; set; }

        public DeleteRangeOperationClaimCommandRequest()
        {

        }

        public DeleteRangeOperationClaimCommandRequest(Guid[] operationClaimIds)
        {
            OperationClaimIds = operationClaimIds;
        }
    }
}
