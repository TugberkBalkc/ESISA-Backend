using ESISA.Core.Application.Dtos.Advert;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.CreateIndividualAdvert
{
    public class CreateIndividualAdvertCommandResponse : CommandResponseBase<IndividualAdvertDto>
    {
        public CreateIndividualAdvertCommandResponse(IContentResponse<IndividualAdvertDto> response) : base(response)
        {
        }
    }
}
