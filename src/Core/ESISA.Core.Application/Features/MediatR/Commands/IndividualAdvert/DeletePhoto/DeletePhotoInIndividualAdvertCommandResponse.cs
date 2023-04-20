using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.DeletePhoto
{
    public class DeletePhotoInIndividualAdvertCommandResponse : CommandResponseBase<Guid>
    {
        public DeletePhotoInIndividualAdvertCommandResponse(IContentResponse<Guid> response) : base(response)
        {
        }
    }
}
