using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Demands.DeleteCategoryDemand
{
    public class DeleteCategoryDemandCommandResponse : CommandResponseBase<Guid>
    {
        public DeleteCategoryDemandCommandResponse(IContentResponse<Guid> response) : base(response)
        {
        }
    }
}
