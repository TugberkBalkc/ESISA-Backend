using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Categories.UpdateMainCategory
{
    public class UpdateMainCategoryCommandResponse : CommandResponseBase<CategoryDto>
    {
        public UpdateMainCategoryCommandResponse(IContentResponse<CategoryDto> response) : base(response)
        {
        }
    }
}

   
