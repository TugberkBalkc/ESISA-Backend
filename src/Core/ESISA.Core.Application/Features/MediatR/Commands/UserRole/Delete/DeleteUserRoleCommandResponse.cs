using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.UserRoles.Delete
{
    public class DeleteUserRoleCommandResponse : CommandResponseBase<Guid>
    {
        public DeleteUserRoleCommandResponse(IContentResponse<Guid> response) : base(response)
        {
        }
    }
}
