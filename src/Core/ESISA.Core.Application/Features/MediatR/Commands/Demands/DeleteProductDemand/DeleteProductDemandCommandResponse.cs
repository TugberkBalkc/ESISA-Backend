using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Demands.DeleteProductDemand
{
    public class DeleteProductDemandCommandResponse : CommandResponseBase<Guid>
    {
        public DeleteProductDemandCommandResponse(IContentResponse<Guid> response) : base(response)
        {
        }
    }
}
