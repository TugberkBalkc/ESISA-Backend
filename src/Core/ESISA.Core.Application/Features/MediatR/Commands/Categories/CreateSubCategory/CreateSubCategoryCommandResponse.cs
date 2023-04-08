using ESISA.Core.Application.Dtos.Category;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Categories.CreateSubCategory
{
    public class CreateSubCategoryCommandResponse : CommandResponseBase<CategoryDto>
    {
        public CreateSubCategoryCommandResponse(IContentResponse<CategoryDto> response) : base(response)
        {
        }
    }
}
