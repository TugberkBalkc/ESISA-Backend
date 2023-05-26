using ESISA.Core.Application.Dtos.Adresses;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Addresses.Create
{
    public class CreateAddressCommandResponse : CommandResponseBase<AddressDto>
    {
        public CreateAddressCommandResponse(IContentResponse<AddressDto> response) : base(response)
        {
        }
    }
}
