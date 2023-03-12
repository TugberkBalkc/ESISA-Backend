using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Demands.DeleteRangeProductDemand
{
    public class DeleteRangeProductDemandCommandResponse : CommandResponseBase<bool>
    {
        public DeleteRangeProductDemandCommandResponse(IContentResponse<bool> response) : base(response)
        {
        }
    }
}
