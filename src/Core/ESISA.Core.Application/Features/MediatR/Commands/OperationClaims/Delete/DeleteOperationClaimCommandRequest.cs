using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.OperationClaims.Delete
{
    public class DeleteOperationClaimCommandRequest : IRequest<DeleteOperationClaimCommandResponse>
    {
        public Guid OperationClaimId { get; set; }

        public DeleteOperationClaimCommandRequest()
        {

        }

        public DeleteOperationClaimCommandRequest(Guid operationClaimId)
        {
            OperationClaimId = operationClaimId;
        }
    }
}
