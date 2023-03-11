using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Brands.Delete
{
    public class DeleteBrandCommandResponse : CommandResponseBase<Guid>
    {
        public DeleteBrandCommandResponse(IContentResponse<Guid> response) : base(response)
        {
        }
    }
}
