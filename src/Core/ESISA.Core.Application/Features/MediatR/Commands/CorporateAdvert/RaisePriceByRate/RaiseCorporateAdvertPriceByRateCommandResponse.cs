using ESISA.Core.Application.Dtos.Advert.CorporateAdverts;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdvert.RaisePriceByRate
{
    public class RaiseCorporateAdvertPriceByRateCommandResponse : CommandResponseBase<CorporateAdvertDto>
    {

        public RaiseCorporateAdvertPriceByRateCommandResponse(IContentResponse<CorporateAdvertDto> response) : base(response)
        {
        }
    }
}
