using ESISA.Core.Application.Features.MediatR.Commands.CorporateAdverts.Create;
using ESISA.Core.Application.Features.MediatR.Commands.IndividualAdverts.Create;
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

        [HttpPost("CreateCorporateAdvert")]
        public async Task<IActionResult> CreateCorporateAdvert([FromBody] CreateCorporateAdvertCommandRequest createCorporateAdvertCommandRequest)
        {
            var response = await _mediator.Send(createCorporateAdvertCommandRequest);

            return base.ActionResultInstanceByResponse(response.Response);
        }
    }
}
