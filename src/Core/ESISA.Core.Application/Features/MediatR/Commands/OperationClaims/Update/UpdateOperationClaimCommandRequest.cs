using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.OperationClaims.Update
{
    public class UpdateOperationClaimCommandRequest : IRequest<UpdateOperationClaimCommandResponse>
    {
        public Guid OperationClaimId { get; set; }
        public bool OperationClaimIsActive { get; set; }
        public String OperationClaimName { get; set; }

        public UpdateOperationClaimCommandRequest()
        {

        }

        public UpdateOperationClaimCommandRequest(Guid operationClaimId, bool operationClaimIsActive, string operationClaimName)
        {
            OperationClaimId = operationClaimId;
            OperationClaimIsActive = operationClaimIsActive;
            OperationClaimName = operationClaimName;
        }
    }
} 
