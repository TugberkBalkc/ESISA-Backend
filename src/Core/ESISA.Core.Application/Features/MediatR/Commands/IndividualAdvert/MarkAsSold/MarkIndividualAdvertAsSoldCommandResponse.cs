using ESISA.Core.Application.Dtos.Advert.IndividualAdverts;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.MarkAsSold
{
    public class MarkIndividualAdvertAsSoldCommandResponse : CommandResponseBase<IndividualAdvertDto>
    {
        public MarkIndividualAdvertAsSoldCommandResponse(IContentResponse<IndividualAdvertDto> response) : base(response)
        {
        }
    }
}
