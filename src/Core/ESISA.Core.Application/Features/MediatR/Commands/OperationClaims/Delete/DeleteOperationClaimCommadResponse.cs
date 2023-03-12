using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.OperationClaims.Delete
{
    public class DeleteOperationClaimCommadResponse : CommandResponseBase<Guid>
    {
        public DeleteOperationClaimCommadResponse(IContentResponse<Guid> response) : base(response)
        {
        }
    }
}
