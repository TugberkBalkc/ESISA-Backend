using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Roles.AddOperationClaim
{
    public class AddOperationClaimToRoleCommandResponse : CommandResponseBase<RoleOperationClaimDto>
    {
        public AddOperationClaimToRoleCommandResponse(IContentResponse<RoleOperationClaimDto> response) : base(response)
        {
        }
    }
}
