using ESISA.Core.Application.Features.MediatR.Commands.Categories.Add;
using ESISA.Core.Application.Features.MediatR.Commands.Categories.AddSubCategory;
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
        public async Task<IActionResult> AddMainCategoryAsync([FromBody] AddMainCategoryCommandRequest addMainCategoryCommandRequest)
        {
            var response = await base._mediator.Send(addMainCategoryCommandRequest);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }

        [HttpPost("AddSubCategory")]
        public async Task<IActionResult> AddSubCategoryAsync([FromBody] AddSubCategoryCommandRequest addSubCategoryCommandRequest)
        {
            var response = await base._mediator.Send(addSubCategoryCommandRequest);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }
    }
}
