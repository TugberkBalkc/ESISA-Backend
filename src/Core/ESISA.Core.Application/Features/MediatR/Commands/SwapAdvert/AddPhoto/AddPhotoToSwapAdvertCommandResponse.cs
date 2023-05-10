using ESISA.Core.Application.Dtos.Advert.Common;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.SwapAdverts.AddPhoto
{
    public class AddPhotoToSwapAdvertCommandResponse : CommandResponseBase<AdvertPhotoPathDto>
    {
        public AddPhotoToSwapAdvertCommandResponse(IContentResponse<AdvertPhotoPathDto> response) : base(response)
        {
        }
    }
}
