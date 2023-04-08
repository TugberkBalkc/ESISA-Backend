using ESISA.Core.Application.Dtos.CorporateCustomer;
using ESISA.Core.Application.Dtos.User;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualStarter.RegisterAsIndividualStarter
{
    public class RegisterAsIndividualStarterCommandResponse : CommandResponseBase<IndividualStarterDto>
    {
        public RegisterAsIndividualStarterCommandResponse(IContentResponse<IndividualStarterDto> response) : base(response)
        {
        }
    }
}
