using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Demands.DeleteRangeBrandDemand
{
    public class DeleteRangeBrandDemandCommandResponse : CommandResponseBase<bool>
    {
        public DeleteRangeBrandDemandCommandResponse(IContentResponse<bool> response) : base(response)
        {
        }
    }
}
