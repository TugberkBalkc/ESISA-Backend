using ESISA.Core.Application.Dtos.Advert.SwapAdvert;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.SwapAdverts.AddSwappableProduct
{
    public class AddSwappableProductCommandResponse : CommandResponseBase<SwapAdvertSwappableProductDto>
    {
        public AddSwappableProductCommandResponse(IContentResponse<SwapAdvertSwappableProductDto> response) : base(response)
        {
        }
    }
}
