using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Addresses.Delete
{
    public class DeleteAddressCommandResponse : CommandResponseBase<Guid>
    {
        public DeleteAddressCommandResponse(IContentResponse<Guid> response) : base(response)
        {
        }
    }
}
