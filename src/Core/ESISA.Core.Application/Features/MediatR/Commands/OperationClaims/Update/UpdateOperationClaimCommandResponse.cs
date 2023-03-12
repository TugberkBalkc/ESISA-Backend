using ESISA.Core.Application.Dtos.Security.Authorization;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.OperationClaims.Update
{
    public class UpdateOperationClaimCommandResponse : CommandResponseBase<OperationClaimDto>
    {
        public UpdateOperationClaimCommandResponse(IContentResponse<OperationClaimDto> response) : base(response)
        {
        }
    }
} 
