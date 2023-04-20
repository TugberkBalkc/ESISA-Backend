using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.Delete
{
    public class DeleteCorporateAdvertCommandResponse : CommandResponseBase<Guid>
    {
        public DeleteCorporateAdvertCommandResponse(IContentResponse<Guid> response) : base(response)
        {
        }
    }
}
