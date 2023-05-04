using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.DeletePhoto
{
    public class DeletePhotoInCorporateAdvertCommandResponse : CommandResponseBase<Guid>
    {
        public DeletePhotoInCorporateAdvertCommandResponse(IContentResponse<Guid> response) : base(response)
        {
        }
    }
}
