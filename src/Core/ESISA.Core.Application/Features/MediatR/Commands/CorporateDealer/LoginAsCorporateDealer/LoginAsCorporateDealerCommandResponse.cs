using ESISA.Core.Application.Dtos.Security.Authentication;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateDealer.LoginAsCorporateDealer
{
    public class LoginAsCorporateDealerCommandResponse : CommandResponseBase<Token>
    {
        public LoginAsCorporateDealerCommandResponse(IContentResponse<Token> response) : base(response)
        {
        }
    }

}
