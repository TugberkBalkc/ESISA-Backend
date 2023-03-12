using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Roles.DeleteOperationClaim
{
    public class DeleteOperationClaimInRoleCommandResponse : CommandResponseBase<Guid>
    {
        public DeleteOperationClaimInRoleCommandResponse(IContentResponse<Guid> response) : base(response)
        {
        }
    }
}
