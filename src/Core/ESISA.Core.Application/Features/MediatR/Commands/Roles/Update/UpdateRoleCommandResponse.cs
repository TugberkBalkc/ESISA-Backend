using ESISA.Core.Application.Dtos.Security.Authorization;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Roles.Update
{
    public class UpdateRoleCommandResponse : CommandResponseBase<RoleDto>
    {
        public UpdateRoleCommandResponse(IContentResponse<RoleDto> response) : base(response)
        {
        }
    }
}
