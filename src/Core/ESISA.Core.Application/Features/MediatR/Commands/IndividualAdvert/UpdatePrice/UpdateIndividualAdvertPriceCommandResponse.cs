using ESISA.Core.Application.Dtos.Advert.IndividualAdverts;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.UpdatePrice
{
    public class UpdateIndividualAdvertPriceCommandResponse : CommandResponseBase<IndividualAdvertDto>
    {
        public UpdateIndividualAdvertPriceCommandResponse(IContentResponse<IndividualAdvertDto> response) : base(response)
        {
        }
    }

}
