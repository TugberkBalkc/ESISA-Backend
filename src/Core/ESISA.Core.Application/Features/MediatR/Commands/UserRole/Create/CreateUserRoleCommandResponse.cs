using ESISA.Core.Application.Dtos.Security.Authorization;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;
using ESISA.Core.Domain.Entities;

namespace ESISA.Core.Application.Features.MediatR.Commands.UserRoles.Create
{
    public class CreateUserRoleCommandResponse : CommandResponseBase<UserRoleDto>
    {
        public CreateUserRoleCommandResponse(IContentResponse<UserRoleDto> response) : base(response)
        {
        }
    }
}
