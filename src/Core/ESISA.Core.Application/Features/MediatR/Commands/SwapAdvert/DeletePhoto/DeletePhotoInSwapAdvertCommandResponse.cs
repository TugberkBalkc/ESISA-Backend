using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.SwapAdverts.DeletePhoto
{
    public class DeletePhotoInSwapAdvertCommandResponse : CommandResponseBase<Guid>
    {
        public DeletePhotoInSwapAdvertCommandResponse(IContentResponse<Guid> response) : base(response)
        {
        }
    }
}
