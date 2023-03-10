using ESISA.Core.Application.Features.MediatR.Commands.Brands.Add;
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
    }
}
