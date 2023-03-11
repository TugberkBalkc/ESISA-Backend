using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Categories.Update
{
    public class UpdateSubCategoryCommandResponse : CommandResponseBase<CategoryDto>
    {
        public UpdateSubCategoryCommandResponse(IContentResponse<CategoryDto> response) : base(response)
        {
        }
    }
}
