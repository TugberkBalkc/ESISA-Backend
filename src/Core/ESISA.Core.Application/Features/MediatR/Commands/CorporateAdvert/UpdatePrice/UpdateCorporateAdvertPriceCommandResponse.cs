using ESISA.Core.Application.Dtos.Advert.CorporateAdverts;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.UpdatePrice
{
    public class UpdateCorporateAdvertPriceCommandResponse : CommandResponseBase<CorporateAdvertDto>
    {
        public UpdateCorporateAdvertPriceCommandResponse(IContentResponse<CorporateAdvertDto> response) : base(response)
        {
        }
    }
}
