using ESISA.Core.Application.Features.MediatR.Commands.Brands.Create;
using ESISA.Core.Application.Features.MediatR.Commands.Brands.Delete;
using ESISA.Core.Application.Features.MediatR.Commands.Brands.DeleteRange;
using ESISA.Core.Application.Features.MediatR.Commands.Brands.Update;
using ESISA.WebAPI.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESISA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : CustomControllerBase
    {
        public BrandsController(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [HttpPost("CreateBrand")]
        public async Task<IActionResult> CreateBrandAsync([FromBody] CreateBrandCommandRequest createBrandCommandRequest)
        {
            var response = await base._mediator.Send(createBrandCommandRequest);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }

        [HttpDelete("DeleteBrand")]
        public async Task<IActionResult> DeleteBrandAsync([FromBody] DeleteBrandCommandRequest deleteBrandCommandRequest)
        {
            var response = await base._mediator.Send(deleteBrandCommandRequest);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }

        [HttpDelete("DeleteRangeBrand")]
        public async Task<IActionResult> DeleteRangeBrandAsync([FromBody] DeleteRangeBrandCommandRequest deleteRangeBrandCommandRequest)
        {
            var response = await base._mediator.Send(deleteRangeBrandCommandRequest);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }

        [HttpPut("UpdateBrand")]
        public async Task<IActionResult> UpdateBrandAsync([FromBody] UpdateBrandCommandRequest updateBrandCommandRequest)
        {
            var response = await base._mediator.Send(updateBrandCommandRequest);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }
    }
}
