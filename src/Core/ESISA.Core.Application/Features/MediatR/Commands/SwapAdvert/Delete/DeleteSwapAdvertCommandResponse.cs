using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.SwapAdverts.Delete
{
    public class DeleteSwapAdvertCommandResponse : CommandResponseBase<Guid>
    {
        public DeleteSwapAdvertCommandResponse(IContentResponse<Guid> response) : base(response)
        {
        }
    }
}
