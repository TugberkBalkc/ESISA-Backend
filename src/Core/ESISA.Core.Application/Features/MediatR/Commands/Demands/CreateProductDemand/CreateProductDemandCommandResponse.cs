using ESISA.Core.Application.Dtos.Demand;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Demands.CreateProductDemand
{
    public class CreateProductDemandCommandResponse : CommandResponseBase<ProductDemandDto>
    {
        public CreateProductDemandCommandResponse(IContentResponse<ProductDemandDto> response) : base(response)
        {
        }
    }
}
