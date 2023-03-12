using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.OperationClaims.Delete
{
    public class DeleteOperationClaimCommadRequest : IRequest<DeleteOperationClaimCommadResponse>
    {
        public Guid OperationClaimId { get; set; }

        public DeleteOperationClaimCommadRequest()
        {

        }

        public DeleteOperationClaimCommadRequest(Guid operationClaimId)
        {
            OperationClaimId = operationClaimId;
        }
    }
}
