using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Categories.AddSubCategory
{
    public class AddSubCategoryCommandResponse : CommandResponseBase<CategoryDto>
    {
        public AddSubCategoryCommandResponse(IContentResponse<CategoryDto> response) : base(response)
        {
        }
    }
}
