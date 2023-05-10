using ESISA.Core.Application.Dtos.Advert.SwapAdvert;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.SwapAdverts.Update
{
    public class UpdateSwapAdvertCommandResponse : CommandResponseBase<SwapAdvertDto>
    {
        public UpdateSwapAdvertCommandResponse(IContentResponse<SwapAdvertDto> response) : base(response)
        {
        }
    }
}
