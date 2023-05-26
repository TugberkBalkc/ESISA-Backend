using ESISA.Core.Application.Dtos.Adresses;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualStarter.AddAddress
{
    public class AddAddressToIndividualCustomerCommandResponse : CommandResponseBase<IndividualCustomerAddressDto>
    {
        public AddAddressToIndividualCustomerCommandResponse(IContentResponse<IndividualCustomerAddressDto> response) : base(response)
        {
        }
    }
}
