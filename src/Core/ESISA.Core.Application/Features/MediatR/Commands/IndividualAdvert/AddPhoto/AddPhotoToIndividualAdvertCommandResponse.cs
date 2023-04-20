using ESISA.Core.Application.Dtos.Advert.Common;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.AddPhoto
{
    public class AddPhotoToIndividualAdvertCommandResponse : CommandResponseBase<AdvertPhotoPathDto>
    {
        public AddPhotoToIndividualAdvertCommandResponse(IContentResponse<AdvertPhotoPathDto> response) : base(response)
        {
        }
    }
}
