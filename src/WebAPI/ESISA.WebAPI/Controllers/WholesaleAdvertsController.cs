using ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.Create;
using ESISA.Core.Application.Features.MediatR.Commands.WholesaleAdverts.Create;
using ESISA.WebAPI.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESISA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WholesaleAdvertsController : CustomControllerBase
    {
        public WholesaleAdvertsController(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [HttpPost("CreateWholesaleAdvert")]
        public async Task<IActionResult> CreateWholesaleAdvertAsync([FromBody] CreateWholesaleAdvertCommandRequest createWholesaleAdvertCommandRequest)
        {
            var response = await _mediator.Send(createWholesaleAdvertCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }
    }
}
