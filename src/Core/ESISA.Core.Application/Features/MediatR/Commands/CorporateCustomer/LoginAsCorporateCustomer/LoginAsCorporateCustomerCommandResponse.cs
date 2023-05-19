using ESISA.Core.Application.Dtos.Security.Authentication;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateCustomer.LoginAsCorporateCustomer
{
    public class LoginAsCorporateCustomerCommandResponse : CommandResponseBase<Token>
    {
        public LoginAsCorporateCustomerCommandResponse(IContentResponse<Token> response) : base(response)
        {
        }
    }
}
