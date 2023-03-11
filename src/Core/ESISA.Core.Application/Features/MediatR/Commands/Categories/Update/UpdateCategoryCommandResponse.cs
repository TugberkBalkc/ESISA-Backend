﻿using ESISA.Core.Application.Dtos;
using ESISA.Core.Application.Features.MediatR.Requests.Common;
using ESISA.Core.Application.Utilities.Response.Common;

namespace ESISA.Core.Application.Features.MediatR.Commands.Categories.Update
{
    public class UpdateCategoryCommandResponse : CommandResponseBase<CategoryDto>
    {
        public UpdateCategoryCommandResponse(IContentResponse<CategoryDto> response) : base(response)
        {
        }
    }
}
