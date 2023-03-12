using ESISA.Core.Application.Dtos.Security.Authorization;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.OperationClaims.Create
{
    public class CreateOperationClaimCommandResponse : CommandResponseBase<OperationClaimDto>
    {
        public CreateOperationClaimCommandResponse(IContentResponse<OperationClaimDto> response) : base(response)
        {
        }
    }
}
