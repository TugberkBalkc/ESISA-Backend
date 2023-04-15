using ESISA.Core.Application.Dtos.Advert.CorporateAdverts;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.Create
{
    public class CreateCorporateAdvertCommandResponse : CommandResponseBase<NotDiscountedCorporateAdvertDto>
    {
        public CreateCorporateAdvertCommandResponse(IContentResponse<NotDiscountedCorporateAdvertDto> response) : base(response)
        {
        }
    }
}
