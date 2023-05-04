using ESISA.Core.Application.Dtos.Advert.CorporateAdverts;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.ReducePriceByRate
{
    public class ReduceCorporateAdvertPriceByRateCommandResponse : CommandResponseBase<CorporateAdvertDto>
    {
        public ReduceCorporateAdvertPriceByRateCommandResponse(IContentResponse<CorporateAdvertDto> response) : base(response)
        {
        }
    }
}
