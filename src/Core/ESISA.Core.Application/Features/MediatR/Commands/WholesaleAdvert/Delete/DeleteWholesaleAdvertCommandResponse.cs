using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.WholesaleAdverts.Delete
{
    public class DeleteWholesaleAdvertCommandResponse : CommandResponseBase<Guid>
    {
        public DeleteWholesaleAdvertCommandResponse(IContentResponse<Guid> response) : base(response)
        {
        }
    }
}
