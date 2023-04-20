using ESISA.Core.Application.Dtos.Advert.IndividualAdverts;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.MarkAsUnsold
{
    public class MarkIndividualAdvertAsUnsoldCommandResponse : CommandResponseBase<IndividualAdvertDto>
    {
        public MarkIndividualAdvertAsUnsoldCommandResponse(IContentResponse<IndividualAdvertDto> response) : base(response)
        {
        }
    }
}
