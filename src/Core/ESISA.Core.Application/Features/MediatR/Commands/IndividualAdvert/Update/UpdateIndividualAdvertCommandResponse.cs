using ESISA.Core.Application.Dtos.Advert.IndividualAdverts;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.Update
{
    public class UpdateIndividualAdvertCommandResponse : CommandResponseBase<IndividualAdvertDto>
    {
        public UpdateIndividualAdvertCommandResponse(IContentResponse<IndividualAdvertDto> response) : base(response)
        {
        }
    }
}
