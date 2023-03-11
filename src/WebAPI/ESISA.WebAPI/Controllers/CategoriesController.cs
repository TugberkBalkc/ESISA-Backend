using ESISA.Core.Application.Features.MediatR.Commands.Categories.CreateMainCategory;
using ESISA.Core.Application.Features.MediatR.Commands.Categories.CreateSubCategory;
using ESISA.Core.Application.Features.MediatR.Commands.Categories.Delete;
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

        [HttpPost("AddMainCategory")]
        public async Task<IActionResult> AddMainCategoryAsync([FromBody] CreateMainCategoryCommandRequest addMainCategoryCommandRequest)
        {
            var response = await base._mediator.Send(addMainCategoryCommandRequest);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }

        [HttpPost("AddSubCategory")]
        public async Task<IActionResult> AddSubCategoryAsync([FromBody] CreateSubCategoryCommandRequest addSubCategoryCommandRequest)
        {
            var response = await base._mediator.Send(addSubCategoryCommandRequest);

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
