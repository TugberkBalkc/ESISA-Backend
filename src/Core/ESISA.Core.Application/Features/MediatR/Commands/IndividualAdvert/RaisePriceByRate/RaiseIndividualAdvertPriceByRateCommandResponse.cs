using ESISA.Core.Application.Dtos.Advert.IndividualAdverts;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.UpdatePriceByRate
{
    public class RaiseIndividualAdvertPriceByRateCommandResponse : CommandResponseBase<IndividualAdvertDto>
    {
        public RaiseIndividualAdvertPriceByRateCommandResponse(IContentResponse<IndividualAdvertDto> response) : base(response)
        {
        }
    }
}
