using ESISA.Core.Application.Dtos.Advert.CorporateAdverts;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.Create
{
    public class CreateCorporateAdvertCommandResponse : CommandResponseBase<CorporateAdvertDto>
    {
        public CreateCorporateAdvertCommandResponse(IContentResponse<CorporateAdvertDto> response) : base(response)
        {
        }
    }
}
