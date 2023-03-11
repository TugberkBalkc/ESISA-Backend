using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Demands.DeleteBrandDemand
{
    public class DeleteBrandDemandCommandResponse : CommandResponseBase<Guid>
    {
        public DeleteBrandDemandCommandResponse(IContentResponse<Guid> response) : base(response)
        {
        }
    }
}
