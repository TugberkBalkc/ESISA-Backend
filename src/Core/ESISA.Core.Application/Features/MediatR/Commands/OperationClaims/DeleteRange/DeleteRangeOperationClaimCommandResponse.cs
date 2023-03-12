using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.OperationClaims.DeleteRange
{
    public class DeleteRangeOperationClaimCommandResponse : CommandResponseBase<bool>
    {
        public DeleteRangeOperationClaimCommandResponse(IContentResponse<bool> response) : base(response)
        {
        }
    }
}
