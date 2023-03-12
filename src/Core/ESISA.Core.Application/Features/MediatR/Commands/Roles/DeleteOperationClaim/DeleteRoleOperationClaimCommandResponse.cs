using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Roles.DeleteOperationClaim
{
    public class DeleteRoleOperationClaimCommandResponse : CommandResponseBase<Guid>
    {
        public DeleteRoleOperationClaimCommandResponse(IContentResponse<Guid> response) : base(response)
        {
        }
    }
}
