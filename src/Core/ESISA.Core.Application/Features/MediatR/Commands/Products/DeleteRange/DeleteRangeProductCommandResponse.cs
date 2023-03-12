using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Products.DeleteRange
{
    public class DeleteRangeProductCommandResponse : CommandResponseBase<bool>
    {
        public DeleteRangeProductCommandResponse(IContentResponse<bool> response) : base(response)
        {
        }
    }
}
