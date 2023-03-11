using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Roles.Delete
{
    public class DeleteRoleCommandResponse : CommandResponseBase<Guid>
    {
        public DeleteRoleCommandResponse(IContentResponse<Guid> response) : base(response)
        {
        }
    }
}
