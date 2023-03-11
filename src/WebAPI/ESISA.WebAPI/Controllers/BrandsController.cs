using ESISA.Core.Application.Features.MediatR.Commands.Brands.Add;
using ESISA.Core.Application.Features.MediatR.Commands.Brands.Delete;
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

        [HttpPost("AddBrand")]
        public async Task<IActionResult> AddBrandAsync([FromBody] AddBrandCommandRequest addBrandCommandRequest)
        {
            var response = await base._mediator.Send(addBrandCommandRequest);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }

        [HttpPost("DeleteBrand")]
        public async Task<IActionResult> DeleteBrandAsync([FromBody] DeleteBrandCommandRequest deleteBrandCommandRequest)
        {
            var response = await base._mediator.Send(deleteBrandCommandRequest);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }

        [HttpPost("UpdateBrand")]
        public async Task<IActionResult> UpdateBrandAsync([FromBody] UpdateBrandCommandRequest updateBrandCommandRequest)
        {
            var response = await base._mediator.Send(updateBrandCommandRequest);

            return response.Response.IsSucceeded == true
                ? Ok(response.Response)
                : BadRequest(response.Response.Title + ":" + response.Response.Message);
        }
    }
}
