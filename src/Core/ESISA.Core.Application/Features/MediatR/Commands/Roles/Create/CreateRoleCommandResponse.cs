using ESISA.Core.Application.Dtos.Security.Authorization;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Roles.Create
{
    public class CreateRoleCommandResponse : CommandResponseBase<RoleDto>
    {
        public CreateRoleCommandResponse(IContentResponse<RoleDto> response) : base(response)
        {
        }
    }
}
