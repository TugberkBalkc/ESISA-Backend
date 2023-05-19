using ESISA.Core.Application.Dtos.User;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateDealer.RegisterAsCorporateDealer
{
    public class RegisterAsCorporateDealerCommandResponse : CommandResponseBase<CorporateDealerDto>
    {
        public RegisterAsCorporateDealerCommandResponse(IContentResponse<CorporateDealerDto> response) : base(response)
        {
        }
    }
}
