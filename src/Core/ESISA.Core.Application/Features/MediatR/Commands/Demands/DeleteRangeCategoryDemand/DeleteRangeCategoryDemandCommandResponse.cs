using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Demands.DeleteRangeCategoryDemand
{
    public class DeleteRangeCategoryDemandCommandResponse : CommandResponseBase<bool>
    {
        public DeleteRangeCategoryDemandCommandResponse(IContentResponse<bool> response) : base(response)
        {
        }
    }
}
