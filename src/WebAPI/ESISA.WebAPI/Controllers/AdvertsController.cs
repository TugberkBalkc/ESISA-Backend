using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.CreateIndividualAdvert;
using ESISA.WebAPI.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESISA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertsController : CustomControllerBase
    {
        public AdvertsController(IHttpContextAccessor httpContextAccessor, IMediator mediator) : base(httpContextAccessor, mediator)
        {
        }

        [HttpPost("CreateIndividualAdvert")]
        public async Task<IActionResult> CretaeIndividualAdvert([FromBody] CreateIndividualAdvertCommandRequest createIndividualAdvertCommandRequest)
        {
            var response = await _mediator.Send(createIndividualAdvertCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }
    }
}
