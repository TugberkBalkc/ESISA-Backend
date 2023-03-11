using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Demands.CreateBrandDemand
{
    public class CreateBrandDemandCommandResponse : CommandResponseBase<BrandDemandDto>
    {
        public CreateBrandDemandCommandResponse(IContentResponse<BrandDemandDto> response) : base(response)
        {
        }
    }
}
