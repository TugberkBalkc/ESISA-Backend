using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.OperationClaims.Create
{
    public class CreateOperationClaimCommandRequest : IRequest<CreateOperationClaimCommandResponse>
    {
        public String OperationClaimName { get; set; }

        public CreateOperationClaimCommandRequest()
        {

        }

        public CreateOperationClaimCommandRequest(string operationClaimName)
        {
            OperationClaimName = operationClaimName;
        }
    }
}
