using ESISA.Core.Application.Features.MediatR.Commands.Categories.CreateMainCategory;
using ESISA.Core.Application.Features.MediatR.Commands.Categories.CreateSubCategory;
using ESISA.Core.Application.Features.MediatR.Commands.Categories.Delete;
using ESISA.Core.Application.Features.MediatR.Commands.Categories.DeleteRange;
using ESISA.Core.Application.Features.MediatR.Commands.Categories.Update;
using ESISA.Core.Application.Features.MediatR.Commands.Categories.UpdateMainCategory;
using ESISA.WebAPI.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }

        [HttpPost("CreateSubCategory")]
        public async Task<IActionResult> CreateSubCategoryAsync([FromBody] CreateSubCategoryCommandRequest createSubCategoryCommandRequest)
        {
            var response = await base._mediator.Send(createSubCategoryCommandRequest);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategoryAsync([FromBody] DeleteCategoryCommandRequest deleteCategoryCommandRequest)
        {
            var response = await base._mediator.Send(deleteCategoryCommandRequest);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }

        [HttpDelete("DeleteRangeCategory")]
        public async Task<IActionResult> DeleteRangeCategoryAsync([FromBody] DeleteRangeCategoryCommandRequest deleteRangeCategoryCommandRequest)
        {
            var response = await base._mediator.Send(deleteRangeCategoryCommandRequest);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }

        [HttpPut("UpdateSubCategory")]
        public async Task<IActionResult> UpdateSubCategoryAsync([FromBody] UpdateSubCategoryCommandRequest updateCategoryCommandRequest)
        {
            var response = await base._mediator.Send(updateCategoryCommandRequest);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }

        [HttpPut("UpdateMainCategory")]
        public async Task<IActionResult> UpdateMainCategoryAsync([FromBody] UpdateMainCategoryCommandRequest updateMainCategoryCommandRequest)
        {
            var response = await base._mediator.Send(updateMainCategoryCommandRequest);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }
    }
}
