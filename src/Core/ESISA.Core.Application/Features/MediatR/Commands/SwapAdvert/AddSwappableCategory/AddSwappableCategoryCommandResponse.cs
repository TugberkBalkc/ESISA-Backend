using ESISA.Core.Application.Dtos.Advert.SwapAdvert;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.SwapAdverts.AddSwappableCategory
{
    public class AddSwappableCategoryCommandResponse : CommandResponseBase<SwapAdvertSwappableCategoryDto>
    {
        public AddSwappableCategoryCommandResponse(IContentResponse<SwapAdvertSwappableCategoryDto> response) : base(response)
        {
        }
    }
}
