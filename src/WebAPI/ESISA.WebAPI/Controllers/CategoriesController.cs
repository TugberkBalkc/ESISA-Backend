﻿using ESISA.Core.Application.Features.MediatR.Commands.Categories.CreateMainCategory;
using ESISA.Core.Application.Features.MediatR.Commands.Categories.CreateSubCategory;
using ESISA.Core.Application.Features.MediatR.Commands.Categories.Delete;
using ESISA.Core.Application.Features.MediatR.Commands.Categories.DeleteRange;
using ESISA.Core.Application.Features.MediatR.Commands.Categories.Update;
using ESISA.Core.Application.Features.MediatR.Commands.Categories.UpdateMainCategory;
using ESISA.Core.Application.Features.MediatR.Queries.Categories.GetChildrenByCategoryId;
using ESISA.WebAPI.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace ESISA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : CustomControllerBase
    {
        public CategoriesController(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [HttpPost("CreateMainCategory")]

        public async Task<IActionResult> CreateMainCategoryAsync([FromBody] CreateMainCategoryCommandRequest createMainCategoryCommandRequest)
        {
            var response = await base._mediator.Send(createMainCategoryCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPost("CreateSubCategory")]
        public async Task<IActionResult> CreateSubCategoryAsync([FromBody] CreateSubCategoryCommandRequest createSubCategoryCommandRequest)
        {
            var response = await base._mediator.Send(createSubCategoryCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }
        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategoryAsync([FromBody] DeleteCategoryCommandRequest deleteCategoryCommandRequest)
        {
            var response = await base._mediator.Send(deleteCategoryCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpDelete("DeleteRangeCategory")]
        public async Task<IActionResult> DeleteRangeCategoryAsync([FromBody] DeleteRangeCategoryCommandRequest deleteRangeCategoryCommandRequest)
        {
            var response = await base._mediator.Send(deleteRangeCategoryCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPut("UpdateSubCategory")]
        public async Task<IActionResult> UpdateSubCategoryAsync([FromBody] UpdateSubCategoryCommandRequest updateCategoryCommandRequest)
        {
            var response = await base._mediator.Send(updateCategoryCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }

        [HttpPut("UpdateMainCategory")]
        public async Task<IActionResult> UpdateMainCategoryAsync([FromBody] UpdateMainCategoryCommandRequest updateMainCategoryCommandRequest)
        {
            var response = await base._mediator.Send(updateMainCategoryCommandRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }


        [HttpGet("GetChildrenByCategoryId")]
        public async Task<IActionResult> GetChildrenByCategoryIdAsync([FromQuery] GetAllChildrenByCategoryIdQueryRequest getChildrenByCategoryIdQueryRequest)
        {
            var response = await base._mediator.Send(getChildrenByCategoryIdQueryRequest);

            return this.ActionResultInstanceByResponse(response.Response);
        }
    }
}
