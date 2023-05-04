using ESISA.Core.Application.Dtos.Advert.Common;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.AddPhoto
{
    public class AddPhotoToCorporateAdvertCommandResponse : CommandResponseBase<AdvertPhotoPathDto>
    {
        public AddPhotoToCorporateAdvertCommandResponse(IContentResponse<AdvertPhotoPathDto> response) : base(response)
        {
        }
    }
}
