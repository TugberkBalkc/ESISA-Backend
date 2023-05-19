using ESISA.Core.Application.Dtos.Security.Authentication;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualStarter.LoginAsIndividualStarter
{
    public class LoginAsIndividualStarterCommandResponse : CommandResponseBase<Token>
    {
        public LoginAsIndividualStarterCommandResponse(IContentResponse<Token> response) : base(response)
        {
        }
    }
}
