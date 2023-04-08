using ESISA.Core.Application.Dtos.CorporateCustomer;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateCustomer.RegisterAsCorporateCustomer
{
    public class RegisterAsCorporateCustomerCommandResponse : CommandResponseBase<CorporateCustomerDto>
    {
        public RegisterAsCorporateCustomerCommandResponse(IContentResponse<CorporateCustomerDto> response) : base(response)
        {
        }
    }
}
