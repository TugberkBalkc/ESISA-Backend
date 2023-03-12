using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Roles.DeleteRange
{
    public class DeleteRangeRoleCommandResponse : CommandResponseBase<bool>
    {
        public DeleteRangeRoleCommandResponse(IContentResponse<bool> response) : base(response)
        {
        }
    }
}
