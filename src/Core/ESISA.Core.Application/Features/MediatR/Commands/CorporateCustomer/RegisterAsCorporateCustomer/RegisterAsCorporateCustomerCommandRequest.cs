using ESISA.Core.Application.Dtos.Security.Authentication.Registrations;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateCustomer.RegisterAsCorporateCustomer
{
    public class RegisterAsCorporateCustomerCommandRequest : IRequest<RegisterAsCorporateCustomerCommandResponse>
    {
        public RegisterCorporateCustomerDto RegisterCorporateCustomerDto { get; set; }

        public RegisterAsCorporateCustomerCommandRequest()
        {

        }

        public RegisterAsCorporateCustomerCommandRequest(RegisterCorporateCustomerDto registerCorporateCustomerDto)
        {
            this.RegisterCorporateCustomerDto = registerCorporateCustomerDto;
        }
    }
}
