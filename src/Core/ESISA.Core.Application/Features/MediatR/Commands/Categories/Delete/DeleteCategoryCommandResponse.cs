using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Categories.Delete
{
    public class DeleteCategoryCommandResponse : CommandResponseBase<Guid>
    {
        public DeleteCategoryCommandResponse(IContentResponse<Guid> response) : base(response)
        {
        }
    }
}
