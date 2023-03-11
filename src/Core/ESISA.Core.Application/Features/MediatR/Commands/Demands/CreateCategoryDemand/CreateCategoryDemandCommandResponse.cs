using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Features.MediatR.Requests.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Demands.CreateCategoryDemand
{
    public class CreateCategoryDemandCommandResponse : CommandResponseBase<CategoryDemandDto>
    {
        public CreateCategoryDemandCommandResponse(Utilities.Response.Common.IContentResponse<CategoryDemandDto> response) : base(response)
        {
        }
    }
}
