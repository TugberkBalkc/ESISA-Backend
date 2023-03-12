using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Categories.DeleteRange
{
    public class DeleteRangeCategoryCommandResponse : CommandResponseBase<bool>
    {
        public DeleteRangeCategoryCommandResponse(IContentResponse<bool> response) : base(response)
        {
        }
    }
}
