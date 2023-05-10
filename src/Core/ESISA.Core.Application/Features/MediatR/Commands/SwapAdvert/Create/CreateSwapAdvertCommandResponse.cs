using ESISA.Core.Application.Dtos.Advert.SwapAdvert;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.SwapAdverts.Create
{
    public class CreateSwapAdvertCommandResponse : CommandResponseBase<SwapAdvertDto>
    {
        public CreateSwapAdvertCommandResponse(IContentResponse<SwapAdvertDto> response) : base(response)
        {
        }
    }
}
