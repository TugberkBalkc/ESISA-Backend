using ESISA.Core.Application.Dtos.Advert.WholesaleAdvert;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.WholesaleAdverts.Create
{
    public class CreateWholesaleAdvertCommandResponse : CommandResponseBase<WholesaleAdvertDto>
    {
        public CreateWholesaleAdvertCommandResponse(IContentResponse<WholesaleAdvertDto> response) : base(response)
        {
        }
    }
}
