using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Brands.DeleteRange
{
    public class DeleteRangeBrandCommandResponse : CommandResponseBase<bool>
    {
        public DeleteRangeBrandCommandResponse(IContentResponse<bool> response) : base(response)
        {
        }
    }
}
